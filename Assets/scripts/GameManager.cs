using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private Texture2D clickedCursorTexture;
    private Vector2 cursorHotspot;

    private CursorController controls;
    
    private static GameManager instance;
    
    public static int childCounter;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        
        controls = new CursorController();
        ChangeCursor(cursorTexture);
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        controls.Mouse.Click.started += _ => StartedClick();
        controls.Mouse.Click.performed += _ => EndedClick();

        childCounter = 0;
    }

    private void StartedClick()
    {
        ChangeCursor(clickedCursorTexture);
    }

    private void EndedClick()
    {
        ChangeCursor(cursorTexture);
    }

    private void ChangeCursor(Texture2D cursorType)
    {
        Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);
        Cursor.SetCursor(cursorType, hotspot, CursorMode.Auto);
    }
}
