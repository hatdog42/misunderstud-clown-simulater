using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChildCountScript : MonoBehaviour
{
    private TMP_Text childCount;

    private void Start()
    {
        childCount = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        childCount.text = GameManager.childCounter.ToString("0");
    }
}
