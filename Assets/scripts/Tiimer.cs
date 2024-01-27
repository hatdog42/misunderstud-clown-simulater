using System;
using UnityEngine;
using TMPro;
public class Tiimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField]private float remaningTime;

    private void Update()
    {
        if (remaningTime > 0)
        {
             remaningTime -= Time.deltaTime;
        }
        else
        {
            remaningTime = 0;
            //YOU LOOSE
        }
       
        int minutes = Mathf.FloorToInt(remaningTime / 60);
        int seconds = Mathf.FloorToInt(remaningTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
