using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HappinessMeter : MonoBehaviour
{
    public float Happiness = 0f;
    public Vector2 eyeL;
    public Vector2 eyeR;
    public Vector2 eyebrowL;
    public Vector2 eyebrowR;
    public Vector2 mouthL;
    public Vector2 mouthR;

    private Vector2 _idealeyeL = new Vector2(10, 10);
    private Vector2 _idealeyeR= new Vector2(20, 10);
    private Vector2 _idealeyebrowL= new Vector2(3, 15);
    private Vector2 _idealeyebrowR= new Vector2(17, 15);
    private Vector2 _idealmouthL= new Vector2(0, 7);
    private Vector2 _idealmouthR= new Vector2(20, 7);
    
    public bool happy;
    public int childCounter;
    private float Total = 0f;
    

    private void CalculateHappiness()
    {
        //can loop through a list?
        //Calculate the distance between the ideal position and the actual position of each sticker and add values together, the lower the value the higher the happiness
        Total+= Vector2.Distance(_idealeyeL, eyeL);
        Total+= Vector2.Distance(_idealeyeR, eyeR);
        Total+= Vector2.Distance(_idealeyebrowL, eyebrowL);
        Total+= Vector2.Distance(_idealeyebrowR, eyebrowR);
        Total+= Vector2.Distance(_idealmouthL, mouthL);
        Total+= Vector2.Distance(_idealmouthR, mouthR);
        print(Total);
        
    }
    
    
    void Start()
    {
        CalculateHappiness();
    }

    // Update is called once per frame
    void Update()
    {
        if (Total < 5)
        {
            happy = true;
            childCounter += 1;
        }
    }
}
