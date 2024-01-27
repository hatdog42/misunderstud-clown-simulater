using System;
using UnityEngine;

public class PlayerFeetControler : MonoBehaviour
{
    public inputControler InputControler;
    public Animator animator;

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (InputControler.moveDirection != Vector2.zero)
        {
            animator.Play("walk");
        }
        else
        {
            //animator.Play("idle");
        }

        switch (InputControler.moveDirection)
        {
            case { x: 0, y: > 0 }:
                _transform.eulerAngles = new Vector3(0, 0, 0);
                break;
            case { x: > 0, y: > 0 }:
                _transform.eulerAngles = new Vector3(0, 0, -45);
                break;
            case { x: > 0, y: 0 }:
                _transform.eulerAngles = new Vector3(0, 0, -90);
                break;
            case { x: > 0, y: < 0 }:
                _transform.eulerAngles = new Vector3(0, 0, -135);
                break;
            case { x: 0, y: < 0 }:
                _transform.eulerAngles = new Vector3(0, 0, -180);
                break;
            case { x: < 0, y: < 0 }:
                _transform.eulerAngles = new Vector3(0, 0, -225);
                break;
            case { x: < 0, y: 0 }:
                _transform.eulerAngles = new Vector3(0, 0, -270);
                break;
            case { x: < 0, y: > 0 }:
                _transform.eulerAngles = new Vector3(0, 0, -315);
                break;
            default:
                print("is idle");
                break;
        }

    }
}
