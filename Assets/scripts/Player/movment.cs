using Unity.VisualScripting;
using UnityEngine;

public class movment : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    private Transform m_transform;

    public Transform AttackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    
    public Camera camera;
    
    private Rigidbody2D _rigidbody2D;
    private inputControler _input;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip screemClip;
    

    [SerializeField]private Animator _animator;

    public static bool canMove = true;
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
            if (_input.attackPressed)
            {
                Attack();
            }
            LAmouse();
        }
        else
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }

    private void LAmouse()
    {
        Vector2 direction = camera.ScreenToWorldPoint
            (Input.mousePosition) - m_transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            m_transform.rotation = rotation;
    }

    private void Attack()
    {
        
        _animator.Play("attack");
            
        Collider2D[] hitEnemies =Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            ChildRunaway childRunaway = enemy.GetComponent<ChildRunaway>();
            
            if (childRunaway != null)
            {
                if (!enemy.CompareTag("trigger"))
                {
                    childRunaway.happy = true;
                    childRunaway.OnChildCaught();
                    _audioSource.PlayOneShot(screemClip);
                }
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;
        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }
    

}
