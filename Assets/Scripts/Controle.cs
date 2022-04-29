using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle : MonoBehaviour
{
    public GameObject jogador;
    public Animation jogadorAnimation;

    CharacterController ccFelpudo;

    int tempoDano;

    // Start is called before the first frame update
    void Start()
    {
        ccFelpudo = GetComponent<CharacterController>();
        jogadorAnimation = jogador.GetComponent<Animation>();

        //Cursor.lockState = CursorLockMode.Locked;
    }

    public void DanoTomado()
    {
        ccFelpudo.Move(Vector3.back);
        InvokeRepeating("EfeitoDano", 0, 0.15f);
    }

    void EfeitoDano()
    {
        tempoDano++;
        jogador.SetActive(!jogador.activeInHierarchy);

        if (tempoDano > 7)
        {
            tempoDano = 0;
            jogador.SetActive(true);
            CancelInvoke();
        }  
    }
}
