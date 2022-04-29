using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegaItem : MonoBehaviour
{
    public GameObject particula;
    public Color cor;

    GameObject gameSystem;
    AudioManagerScript sFx;

    // Start is called before the first frame update
    void Start()
    {
        gameSystem = GameObject.Find("GameSystem");
        sFx = GameObject.FindObjectOfType<AudioManagerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Jogador")
        {
            switch (gameObject.tag)
            {
                case "Ovo": PegaOvo(); break;
                case "Pena": PegaPena(); break;
                case "Estrela": PegaEstrela(); break;
                default: break;
            }
        }

        if (particula != null)
        {
            GameObject minhaParticula = Instantiate(particula) as GameObject;
            minhaParticula.transform.position = this.transform.position;
            var main = minhaParticula.gameObject.GetComponent<ParticleSystem>().main;
            main.startColor = cor;
            Destroy(minhaParticula, 0.5f);
        }
        Destroy(this.gameObject);
    }

    void PegaOvo()
    {
        gameSystem.SendMessage("PegaOvo");
        sFx.SFX_Item(1);
    }

    void PegaPena()
    {
        gameSystem.SendMessage("PegaPena");
        sFx.SFX_Item(2);
    }

    void PegaEstrela()
    {
        gameSystem.SendMessage("PegaEstrela");
        sFx.SFX_Item(1);
    }
}
