using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HappinessMeter : MonoBehaviour
{
    [SerializeField] private sceneManeger _sceneManager;
    public float Happiness;
    public RectTransform eyeLeft;
    public RectTransform eyeRight;
    public RectTransform eyebrowLeft;
    public RectTransform eyebrowRight;
    public RectTransform mouthRight;
    public RectTransform mouthLeft;
    
    private CursorController controls;
    private AudioSource _audio;
    public AudioClip stretchySound;
    public AudioClip childLaughing;

    /*[SerializeField] private Vector3 _idealeyeL = new Vector3(-2, 2, 0);
    [SerializeField] private Vector3 _idealeyeR= new Vector3(2, 2, 0);
    [SerializeField] private Vector3 _idealeyebrowL= new Vector3(-1, 3,0);
    [SerializeField] private Vector3 _idealeyebrowR= new Vector3(1, 3, 0);
    [SerializeField] private Vector3 _idealmouthL= new Vector3(-2.2f, 1, 0);
    [SerializeField] private Vector3 _idealmouthR= new Vector3(2.4f, 1, 0);
    */

    private Vector3 _idealeyeL;
    private Vector3 _idealeyeR;
    private Vector3 _idealeyebrowL;
    private Vector3 _idealeyebrowR;
    private Vector3 _idealmouthL;
    private Vector3 _idealmouthR;
    
    public bool happy;
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
        
        if (Total > 1)
        {
            Happiness = 0.2f;
        }
        if (Total > 5)
        {
            Happiness = 0.5f;
        }
        if (Total > 10)
        {
            Happiness = 0.7f;
        }
        if (Total > 15)
        {
            Happiness = 1f;
        }
    }

    private void Awake()
    {
        controls = new CursorController();
    }

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        happy = true;
        StartCoroutine(SetPos());
        movment.canMove = false;
        
        controls.Mouse.Click.started += _ => StartedClick();
    }
    private void StartedClick()
    {
        _audio.Stop();
        _audio.PlayOneShot(stretchySound);
    }
  
    void Update()
    {
        if (!happy)
        {
            CalculateHappiness();
            if (Total > 16)
            {
                happy = true;
                GameManager.childCounter += 1;
                //_audio.PlayOneShot(childLaughing);
                _animator.Play("PanelExit");
                movment.canMove = true;
                if (GameManager.childCounter >= 6)
                {
                    _sceneManager.LoadSceneByName("WinScene");
                }
                else
                {
                    StartCoroutine(PanelDestroy());
                }
            }
        }
    }

    private IEnumerator SetPos()
    {
        yield return new WaitForSeconds(1.5f);
        
        _idealeyeL = eyeLeft.position;
        _idealeyeR = eyeRight.position;
        _idealeyebrowL = eyebrowLeft.position;
        _idealeyebrowR = eyebrowRight.position;
        _idealmouthL = mouthLeft.position;
        _idealmouthR = mouthRight.position;
        happy = false;
    }
    
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private IEnumerator PanelDestroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
