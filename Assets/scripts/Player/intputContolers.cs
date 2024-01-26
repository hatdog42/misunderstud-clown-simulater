using UnityEngine;

public class intputControler : MonoBehaviour
{
    [HideInInspector] public Vector2 moveDirection;
    [HideInInspector] public bool attackPressed;
    
    //public static intputControler Instance { get; private set; }
    
    private Controls _input;
    
    private void Update()
    {
        moveDirection = _input.player.movment.ReadValue<Vector2>();
        attackPressed = _input.player.Attack.WasPressedThisFrame();
    }
    /*private void Awake()
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
    }*/
}
