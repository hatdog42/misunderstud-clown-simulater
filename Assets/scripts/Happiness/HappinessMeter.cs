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
    

    private Vector3 _idealeyeL = new Vector3(10, 10, 0);
    private Vector3 _idealeyeR= new Vector3(20, 10, 0);
    private Vector3 _idealeyebrowL= new Vector3(3, 15,0);
    private Vector3 _idealeyebrowR= new Vector3(17, 15, 0);
    private Vector3 _idealmouthL= new Vector3(0, 7, 0);
    private Vector3 _idealmouthR= new Vector3(20, 7, 0);
    
    
    public bool happy;
    public int childCounter;
    private float Total = 0f;
    

    private void CalculateHappiness()
    {
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
        CalculateHappiness();
        if (Total < 1)
        {
            happy = true;
            childCounter += 1;
        }
    }
    
    

    // Update is called once per frame
    void Update()
    {
       
    }
}
