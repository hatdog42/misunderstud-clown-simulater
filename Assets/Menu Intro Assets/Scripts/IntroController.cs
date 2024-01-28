using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    [SerializeField] private Animator fade;
    private void Start()
    {
        fade.Play("FadeNone");
        Invoke("SceneFade",30);
    }

    private void SceneFade()
    {
        fade.Play("FadeOut");
        Invoke("PlayNextScene",1.2f);
    }

    private void PlayNextScene()
    {
        SceneManager.LoadScene("Gamescene");
    }
}
