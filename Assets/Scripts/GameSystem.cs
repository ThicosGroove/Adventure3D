using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    public GameObject cameraPrincipal;
    public GameObject cutscene;

    public Animator musicTransition;
    public Animator canvasTransition;

    public Image iconeEnergia;
    public TMP_Text textoVidas;
    public TMP_Text textoOvo;

    public Sprite[] iconesEnergia;

    GameObject jogador;

    GameObject[] totalOvos;
    TimeLineController timeLine;

    int ovos = 0;
    [SerializeField] int energia;
    [SerializeField] int vidas;
    [SerializeField] float cutsceneTime;

    // Start is called before the first frame update
    void Start()
    {
        iconeEnergia.GetComponent<Image>().sprite = iconesEnergia[energia];
        timeLine = GameObject.FindObjectOfType<TimeLineController>();

        jogador = GameObject.Find("Jogador");

        totalOvos = GameObject.FindGameObjectsWithTag("Ovo");
        textoOvo.text = ovos.ToString() + "/" + totalOvos.Length;
        textoVidas.text = "X " + vidas;
    }

    public void PegaOvo()
    {
        ovos++;
        textoOvo.text = ovos.ToString() + "/" + totalOvos.Length;
        if (totalOvos.Length == ovos)
        {
            StartCoroutine(PegouTodosOvos());
        }
    }

    IEnumerator PegouTodosOvos()
    {
        musicTransition.SetTrigger("In");
        canvasTransition.SetTrigger("Out");
        yield return new WaitForSeconds(1f);

        timeLine.PlayCutscene();
        cutscene.SetActive(true);
        cameraPrincipal.SetActive(false);
        StartCoroutine(Cutscene());
    }

    IEnumerator Cutscene()
    {
        yield return new WaitForSeconds(cutsceneTime);
        cameraPrincipal.SetActive(true);
        cutscene.SetActive(false);
        musicTransition.SetTrigger("Out");
        canvasTransition.SetTrigger("In");
    }

    public void PegaPena()
    {
        energia++;
        if (energia > 8)
        {
            energia = 8;
        }
        iconeEnergia.GetComponent<Image>().sprite = iconesEnergia[energia];
    }

    public void DanoVida()
    {
        energia--;
        jogador.SendMessage("DanoTomado");
        if (energia <= 0 )
        {
            jogador.SendMessage("Morreu");
            energia = 8;

            RestartLevel();        
        }
        iconeEnergia.GetComponent<Image>().sprite = iconesEnergia[energia];
    }

    public void RestartLevel()
    {
        vidas--;
        textoVidas.text = "X" + vidas;
        if (vidas == 0)
        {
            SceneManager.LoadScene("Perdeu");
        }
    }

    public void PegaEstrela()
    {
        StartCoroutine(TransicaoScene());
    }

    public IEnumerator TransicaoMorte()
    {
        musicTransition.SetTrigger("In");
        canvasTransition.SetTrigger("Out");

        yield return new WaitForSeconds(1f);

        musicTransition.SetTrigger("Out");
        canvasTransition.SetTrigger("In");
    }

    public IEnumerator TransicaoScene()
    {
        musicTransition.SetTrigger("In");
        canvasTransition.SetTrigger("Win");

        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        musicTransition.SetTrigger("Out");
        canvasTransition.SetTrigger("In");
    }

}
