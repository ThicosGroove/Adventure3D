using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineController : MonoBehaviour
{
    public PlayableDirector playableDirector;

     public void PlayCutscene()
    {
        playableDirector.Play();
    }
}
