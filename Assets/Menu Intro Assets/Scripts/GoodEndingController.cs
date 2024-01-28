using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoodEndingController : MonoBehaviour
{
    private void Start()
    {
        Invoke("PlayNextScene",9);
    }

    private void PlayNextScene()
    {
        SceneManager.LoadScene("Main Menu");
    }
}