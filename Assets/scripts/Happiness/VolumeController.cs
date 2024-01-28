using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    private AudioSource m_MyAudioSource;
    private HappinessMeter _happinessMeter;

    public AudioClip laughClip;
    void Start()
    {
        _happinessMeter = GetComponent<HappinessMeter>();
        m_MyAudioSource = GetComponent<AudioSource>();
        m_MyAudioSource.Play();
    }

    void OnChange()
    {
        
        //get the happiness (value from 0 to 1) variable based on the total variable form happinessMeter
        m_MyAudioSource.volume = _happinessMeter.Happiness;
    }

    // Update is called once per frame
    void Update()
    {
        m_MyAudioSource.volume = _happinessMeter.Happiness;
    }
}
