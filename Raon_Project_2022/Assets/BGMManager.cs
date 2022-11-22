using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioClip[] BGM;
    AudioSource _audioSource;

    int num = 0;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(BGM[num]);
            num++;
            if(num >= 2)
            {
                num = 0;
            }
        }
    }
}
