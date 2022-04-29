using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_CP : MonoBehaviour
{
    public GameObject particle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Jogador")
        {
            particle.SetActive(true);
        }
    }
}
