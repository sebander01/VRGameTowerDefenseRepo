using UnityEngine;
using UnityEngine.AI;

public class MoveUntilClose : MonoBehaviour, IMoveable
{
    [SerializeField] private float distance;
    [SerializeField] private float speed;
    
    private NavMeshAgent _agent;
    
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.speed = speed;
    }

    public void MoveTowardsTarget(Transform player)
    {
        Vector3 directionToPlayer = player.position - transform.position;

        transform.forward = directionToPlayer.normalized;
        _agent.SetDestination(transform.position + (directionToPlayer - directionToPlayer.normalized * distance));
    }
}
