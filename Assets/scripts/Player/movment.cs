using UnityEngine;

public class movment : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;


    private Rigidbody2D _rigidbody2D;
    private intputControler _input;
    private void Start()
    {
        _input = GetComponent<intputControler>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _rigidbody2D.velocity = new Vector2(_input.moveDirection.x * moveSpeed, _input.moveDirection.y * moveSpeed);
    }

   
}
