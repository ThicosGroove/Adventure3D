using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CP : MonoBehaviour
{
    Vector3 posicaoInicial;

    void Start()
    {
        posicaoInicial = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            posicaoInicial = this.transform.position;
            Physics.SyncTransforms();
        }
    }

    public void Morreu()
    {
        transform.position = posicaoInicial;
        Physics.SyncTransforms();
    }
}
