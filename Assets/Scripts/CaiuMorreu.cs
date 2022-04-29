using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaiuMorreu : MonoBehaviour
{
    GameObject gameSystem;
    GameObject jogador;

    private void Start()
    {
        jogador = GameObject.Find("Jogador");
        gameSystem = GameObject.Find("GameSystem");
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Jogador")
        {
            gameSystem.SendMessage("TransicaoMorte");
            StartCoroutine(TransicaoMorte());
        }
    }

    IEnumerator TransicaoMorte()
    {
        yield return new WaitForSeconds(1f); 

        jogador.SendMessage("Morreu");
        gameSystem.SendMessage("RestartLevel");
    }


}
