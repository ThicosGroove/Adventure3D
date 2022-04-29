using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fogo : MonoBehaviour
{
    GameObject gameSystem;

    void Start()
    {
        gameSystem = GameObject.Find("GameSystem");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Jogador")
        {
            gameSystem.SendMessage("DanoVida");
        }
    }
}
