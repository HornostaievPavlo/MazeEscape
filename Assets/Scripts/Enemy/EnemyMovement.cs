using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform startPosition;
    public Transform endPosition;

    private NavMeshAgent navMeshAgent;

    private Transform currentDestination;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetRandomDestination();
    }

    private void Update()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.1f)
            SetRandomDestination();
    }

    private void SetRandomDestination()
    {
        currentDestination = Random.Range(0, 2) == 0 ? startPosition : endPosition;

        navMeshAgent.SetDestination(currentDestination.position);
    }
}
