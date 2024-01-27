using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HappinessMeter : MonoBehaviour
{
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
        
    }
    
    void Start()
    {
        mouthLeft = GameObject.Find("ML").GetComponent<Transform>();
        mouthLeft = GameObject.Find("MR").GetComponent<Transform>();
        mouthLeft = GameObject.Find("EL").GetComponent<Transform>();
        mouthLeft = GameObject.Find("ER").GetComponent<Transform>();
        mouthLeft = GameObject.Find("EBL").GetComponent<Transform>();
        mouthLeft = GameObject.Find("EBR").GetComponent<Transform>();
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
            }
        }
    }
}
