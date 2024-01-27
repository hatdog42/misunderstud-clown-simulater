using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class ChildRunaway : MonoBehaviour
{
    [SerializeField] private float displasmendDist = 5f;
    
    [SerializeField] private NavMeshAgent _agent = null;
    [SerializeField] private Transform target = null;
    
    private bool happy = false;
    private bool wantToRunAway = false;

    private Transform childPos;

    private float runAngle;

    private void Start()
    {
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
}
