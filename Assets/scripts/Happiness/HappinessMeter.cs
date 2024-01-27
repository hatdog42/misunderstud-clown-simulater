using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HappinessMeter : MonoBehaviour
{
    public float Happiness;
    public Transform eyeLeft;
    public Transform eyeRight;
    public Transform eyebrowLeft;
    public Transform eyebrowRight;
    public Transform mouthRight;
    public Transform mouthLeft;
    

    private Vector3 _idealeyeL = new Vector3(-2, 2, 0);
    private Vector3 _idealeyeR= new Vector3(2, 2, 0);
    private Vector3 _idealeyebrowL= new Vector3(-1, 3,0);
    private Vector3 _idealeyebrowR= new Vector3(1, 3, 0);
    private Vector3 _idealmouthL= new Vector3(-2.2f, 1, 0);
    private Vector3 _idealmouthR= new Vector3(2.4f, 1, 0);
    
    
    public bool happy;
    public int childCounter;
    private float Total;

    private Animator _animator;

    private void CalculateHappiness()
    {
        Total = 0;
        //can loop through a list?
        //Calculate the distance between the ideal position and the actual position of each sticker and add values together, the lower the value the higher the happiness
        Total+= Vector3.Distance(_idealeyeL, eyeLeft.position);
        Total+= Vector3.Distance(_idealeyeR, eyeRight.position);
        Total+= Vector3.Distance(_idealeyebrowL, eyebrowLeft.position);
        Total+= Vector3.Distance(_idealeyebrowR, eyebrowRight.position);
        Total+= Vector3.Distance(_idealmouthL, mouthLeft.position);
        Total+= Vector3.Distance(_idealmouthR, mouthRight.position);
        print(Total);
        if (Total is < 10 and > 8)
        {
            Happiness = 0.2f;
        }
        if (Total is < 8 and > 6)
        {
            Happiness = 0.5f;
        }
        if (Total is < 6 and > 3.5f)
        {
            Happiness = 0.7f;
        }
        if (Total < 3.5)
        {
            Happiness = 1f;
        }
        



    }
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
  
    void Update()
    {
        if (!happy)
        {
            CalculateHappiness();
            if (Total < 3)
            {
                happy = true;
                childCounter += 1;
                //_animator.Play("PanelExit");
            }
        }
    }
}
