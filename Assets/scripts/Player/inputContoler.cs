using UnityEngine;

public class inputControler : MonoBehaviour
{
    [HideInInspector] public Vector2 moveDirection;
    [HideInInspector] public bool attackPressed;

    private static inputControler Instance { get; set; }
    
    private Controls _input;
    
    private void Update()
    {
        moveDirection = _input.player.moveDirection.ReadValue<Vector2>();
        attackPressed = _input.player.Attack.WasPressedThisFrame();
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        _input = new Controls();
    }
    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
}
