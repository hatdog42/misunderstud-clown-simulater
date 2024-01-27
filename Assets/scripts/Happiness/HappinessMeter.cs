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


    [SerializeField] private GameObject _idealeyeL;
    [SerializeField] private GameObject _idealeyeR;
    [SerializeField] private GameObject _idealeyebrowL;
    [SerializeField] private GameObject _idealeyebrowR;
    [SerializeField] private GameObject _idealmouthL;
    [SerializeField] private GameObject _idealmouthR;

    private Vector3 eyeLPos, eyeRPos, browLPos, browRPos, mouthLPos, mouthRPos;
    
    
    public bool happy;
    public int childCounter;
    private float Total;

    private Animator _animator;

    private void CalculateHappiness()
    {
        Total = 0;
        //can loop through a list?
        //Calculate the distance between the ideal position and the actual position of each sticker and add values together, the lower the value the higher the happiness
        Total+= Vector3.Distance(eyeLPos, eyeLeft.position);
        Total+= Vector3.Distance(eyeRPos, eyeRight.position);
        Total+= Vector3.Distance(browLPos, eyebrowLeft.position);
        Total+= Vector3.Distance(browRPos, eyebrowRight.position);
        Total+= Vector3.Distance(mouthLPos, mouthLeft.position);
        Total+= Vector3.Distance(mouthRPos, mouthRight.position);
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
        
        eyeLPos = _idealeyeL.transform.position;
        eyeRPos = _idealeyeR.transform.position;
        browLPos = _idealeyebrowL.transform.position;
        browRPos = _idealeyebrowR.transform.position;
        mouthLPos = _idealmouthL.transform.position;
        mouthRPos = _idealmouthR.transform.position;
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
