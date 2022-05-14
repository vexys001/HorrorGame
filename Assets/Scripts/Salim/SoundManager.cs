using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource Source01;
    public AudioSource Source02;

    private AudioSource _currentSource;

    public float FadeTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        FadeIn();
        FadeOutOtherSound();
    }

    void Triggered(int id)
    {
        if (id == 0)
        {
            PlayAudio01();
        }
        else if (id == 1)
        {
            PlayAudio02();
        }
        else PlaySilence();
    }

    void PlaySilence()
    {
        _currentSource = null;
    }

    void PlayAudio01()
    {
        StartFadeIn(Source01);
    }

    void PlayAudio02()
    {
        StartFadeIn(Source02);
    }

    void StartFadeIn(AudioSource newSound)
    {
        if (_currentSource != newSound)
        {
            _currentSource = newSound;

            _currentSource.Play();
            _currentSource.volume = 0;
        }
    }

    void FadeIn()
    {
        if (_currentSource && _currentSource.volume < 1)
        {
            _currentSource.volume = Mathf.MoveTowards(_currentSource.volume, 1, 1 / FadeTime * Time.deltaTime);
        }
    }

    void FadeOutOtherSound()
    {
        if (_currentSource)
        {
            if (_currentSource == Source01)
            {
                if (Source02.volume != 0) Source02.volume = Mathf.MoveTowards(Source02.volume, 0, 1 / FadeTime * Time.deltaTime);
                else if (Source02.isPlaying)
                {
                    Source02.Stop();
                }
            }
            else
            {
                if (Source01.volume != 0) Source01.volume = Mathf.MoveTowards(Source01.volume, 0, 1 / FadeTime * Time.deltaTime);
                else if (Source01.isPlaying)
                {
                    Source01.Stop();
                }
            }
        }
    }
}
