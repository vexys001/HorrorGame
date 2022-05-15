using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteAudioTrigger : Scare
{
    public AudioSource RemoteSource;
    public AudioClip ClipToPlay;
    
    public override void ScarePlayer()
    {
        RemoteSource.PlayOneShot(ClipToPlay);
    }
}
