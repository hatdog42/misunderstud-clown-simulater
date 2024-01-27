using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator fade;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioSource _mainMenuMusic;

    private bool fadeIsHappening;
    
    private void Start()
    { 
        fadeIsHappening = false;
    }

    public void OnPlayClicked()
    {
        fade.Play("FadeOut");
        fadeIsHappening = true;
        Invoke("PlayIntro",1);
        
    }
    

    public void OnExitClicked()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
    
    
    public void NosePush()
    {
        _audioSource.Play();
    }

    private void PlayIntro()
    {
        SceneManager.LoadScene("Intro");
    }

    private void Update()
    {
        if(!fadeIsHappening) return;
        _mainMenuMusic.volume -= 0.06f * Time.deltaTime;
    }
}
