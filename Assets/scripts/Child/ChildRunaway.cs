using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class ChildRunaway : MonoBehaviour
{
    [SerializeField] private float displasmendDist = 5f;
    
    [SerializeField] private NavMeshAgent _agent = null;
    [SerializeField] private Transform target = null;
    

    public bool happy = false;
    private bool wantToRunAway = false;

    private Transform childPos;
    private float lookatAngle = -90f;

    private float runAngle;

    [SerializeField] private GameObject facePanel;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private void Start()
    {
        childPos = GetComponent<Transform>();
        if (_agent == null)
            if (!TryGetComponent(out _agent))
                Debug.LogWarning(name + "needs navmesh agent");
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void Update()
    {
        if (target == null)
            return;
        if (happy)
        {
            if (target)
                MoveToTarget();
        }
        else if (!happy && wantToRunAway)
        {
            Vector2 normDir = (target.position - transform.position).normalized;

            
            {
                
            }
            normDir = Quaternion.AngleAxis(runAngle, Vector3.forward)* normDir;
                
            MoveToPos(transform.position - new Vector3(normDir.x,normDir.y,0) * displasmendDist);
        }
        
    }
    
    private void MoveToTarget()
    {
        _agent.SetDestination(target.position);
        _agent.isStopped = false;
    }

    private void MoveToPos(Vector2 pos)
    {
        _agent.SetDestination(pos);
        _agent.isStopped = false;
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawLine(target.position, transform.position);
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            wantToRunAway = true;
                    if (Random.Range(1, 2) == 1)
                    {
                        runAngle = 45;
                    }
                    else
                    {
                        runAngle = -45;
                    }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
            wantToRunAway = false;
    }

    public void OnChildCaught()
    {
        if (!happy)
        {
            lookatAngle = 90f;
            _audioSource.PlayOneShot(_audioClip);
            facePanel.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (childPos != null && target != null)
            {
                Vector2 direction =   target.position - childPos.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle - lookatAngle, Vector3.forward);
                childPos.rotation = rotation;
            }
            else
            {
                print("somting is null");
            }
        }
        
    }
}
