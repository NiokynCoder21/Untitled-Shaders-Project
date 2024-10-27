using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PissCutscence : MonoBehaviour
{
    public PlayableDirector timelineToPlay;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HandTorch"))
        {
            timelineToPlay.Play();
        }
    }
}
