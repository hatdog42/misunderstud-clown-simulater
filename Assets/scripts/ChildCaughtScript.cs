using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChildCaughtScript : MonoBehaviour
{
    [SerializeField] private GameObject facePanel;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            facePanel.SetActive(true);
            //make child stop moving?
        }
    }
}
