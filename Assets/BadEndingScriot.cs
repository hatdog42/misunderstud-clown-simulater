using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadEndingController : MonoBehaviour
{
    private void Start()
    {
        Invoke("PlayNextScene",13);
    }

    private void PlayNextScene()
    {
        SceneManager.LoadScene("Main Menu");
    }
}