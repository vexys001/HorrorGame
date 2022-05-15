using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoScare : Scare
{
    public VideoPlayer VdPlayer;

    public override void ScarePlayer()
    {
        VdPlayer.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
