using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] SongClips;
    private AudioSource _audioSrc;

    private int lastSongPlayed;
    // Start is called before the first frame update
    void Start()
    {
        _audioSrc = GetComponent<AudioSource>();

        lastSongPlayed = (int)Random.Range(0, SongClips.Length);

        _audioSrc.clip = SongClips[lastSongPlayed];
        _audioSrc.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            int newSong;
            do
            {
                newSong = (int)Random.Range(0, SongClips.Length);
            } while (newSong == lastSongPlayed);

            lastSongPlayed = newSong;

            _audioSrc.clip = SongClips[lastSongPlayed];
            _audioSrc.Play();
        }
    }
}
