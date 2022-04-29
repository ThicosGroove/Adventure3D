using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour
{
    public AudioClip[] bgMusics;
    
    AudioSource audioSource;
    Animator animator;

    [SerializeField] int numberOfClips = 0;


    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();

        audioSource.clip = bgMusics[numberOfClips];

        StartCoroutine(NextClip());
    }

    IEnumerator NextClip()
    {
        yield return new WaitUntil(() => audioSource.isPlaying == false);
        LoopMusic();
    }

    void LoopMusic()
    {
        numberOfClips++;

        if (numberOfClips >= bgMusics.Length)
        {          
            numberOfClips = 0;
        }

        audioSource.clip = bgMusics[numberOfClips];

        audioSource.Play();
        //StartCoroutine(MusicFade());

        StartCoroutine(NextClip());
    }

    IEnumerator MusicFade()
    {
        //animator.SetTrigger("Out");

        yield return new WaitForSeconds(1f);

        //animator.SetTrigger("In");
        audioSource.Play();
    }
}
