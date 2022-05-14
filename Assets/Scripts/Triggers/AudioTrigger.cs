using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    private AudioSource _audioSource;

    public bool TriggerOnce;
    public string TriggerTarget;
    public AudioClip _clipToPlay;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals(TriggerTarget))
        {
            _audioSource.PlayOneShot(_clipToPlay);
        }
    }
}
