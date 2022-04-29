using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{

    public GameObject[] audioSources;

    public void SFX_Item(int item)
    {
        audioSources[item].GetComponent<AudioSource>().Play();
    }

}
