using UnityEngine;

public class movment : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    private Transform m_transform;

    public Transform AttackPoint;
    public float attackRange = 0.7f;
    public LayerMask enemyLayers;
    
    public Camera camera;
    
    private Rigidbody2D _rigidbody2D;
    private inputControler _input;

    private static bool canMove;
    private void Start()
    {
        m_transform = GetComponent<Transform>();
        _input = GetComponent<inputControler>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (canMove)
        {
            _rigidbody2D.velocity = new Vector2(_input.moveDirection.x * moveSpeed, _input.moveDirection.y * moveSpeed);
        }

        if (_input.attackPressed)
        {
            Attack();
        }
        
        LAmouse();
    }

    private void LAmouse()
    {
        Vector2 direction = camera.ScreenToWorldPoint
            (Input.mousePosition) - m_transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            m_transform.rotation = rotation;
    }

    private void Attack()
    {
        Collider2D[] hitEnemies =Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            print("hit" + name);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;
        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }
    

}
