using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HappinessMeter : MonoBehaviour
{
    public float Happiness;
    public RectTransform eyeLeft;
    public RectTransform eyeRight;
    public RectTransform eyebrowLeft;
    public RectTransform eyebrowRight;
    public RectTransform mouthRight;
    public RectTransform mouthLeft;


    /*[SerializeField] private Vector3 _idealeyeL = new Vector3(-2, 2, 0);
    [SerializeField] private Vector3 _idealeyeR= new Vector3(2, 2, 0);
    [SerializeField] private Vector3 _idealeyebrowL= new Vector3(-1, 3,0);
    [SerializeField] private Vector3 _idealeyebrowR= new Vector3(1, 3, 0);
    [SerializeField] private Vector3 _idealmouthL= new Vector3(-2.2f, 1, 0);
    [SerializeField] private Vector3 _idealmouthR= new Vector3(2.4f, 1, 0);
    */

    private RectTransform _idealeyeL;
    private RectTransform _idealeyeR;
    private RectTransform _idealeyebrowL;
    private RectTransform _idealeyebrowR;
    private RectTransform _idealmouthL;
    private RectTransform _idealmouthR;
    
    public bool happy;
    public int childCounter;
    private float Total;

    private Animator _animator;

    private void CalculateHappiness()
    {
        Total = 0;
        //can loop through a list?
        //Calculate the distance between the ideal position and the actual position of each sticker and add values together, the lower the value the higher the happiness
        Total+= Vector3.Distance(_idealeyeL.position, eyeLeft.position);
        Total+= Vector3.Distance(_idealeyeR.position, eyeRight.position);
        Total+= Vector3.Distance(_idealeyebrowL.position, eyebrowLeft.position);
        Total+= Vector3.Distance(_idealeyebrowR.position, eyebrowRight.position);
        Total+= Vector3.Distance(_idealmouthL.position, mouthLeft.position);
        Total+= Vector3.Distance(_idealmouthR.position, mouthRight.position);
        print(Total);
        if (Total > 5)
        {
            Happiness = 0.2f;
        }
        if (Total > 10)
        {
            Happiness = 0.5f;
        }
        if (Total > 15)
        {
            Happiness = 0.7f;
        }
        if (Total > 20)
        {
            Happiness = 1f;
            //animate panel leaving and destroy(gameobject)
            
            //check if childcounter == 6 if so end game, victory
        }
    }
    
    void Start()
    {
        _animator = GetComponent<Animator>();

        _idealeyeL.position = eyeLeft.position;
        _idealeyeR.position = eyeRight.position;
        _idealeyebrowL.position = eyebrowLeft.position;
        _idealeyebrowR.position = eyebrowRight.position;
        _idealmouthL.position = mouthLeft.position;
        _idealmouthR.position = mouthRight.position;

        //StartCoroutine(FaceMiniGame());
        
        //find location of all dragging spots, once all are moved a certain amount, total comes back true
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
                _animator.Play("PanelExit");
            }
        }
    }

    private IEnumerator FaceMiniGame()
    {
        yield return new WaitForSeconds(15);
        gameObject.SetActive(false);
    }
}
