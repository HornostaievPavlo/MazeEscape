using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform startPosition;
    public Transform endPosition;

    private NavMeshAgent agent;

    public Transform playerTransform;

    public bool isPlayerInSight;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetRandomDestination();

        isPlayerInSight = false;
        EventsHandler.PlayerKilled.AddListener(ReturnToPath);
    }

    private void Update() => MoveAgent();

    private void MoveAgent()
    {
        if (!isPlayerInSight)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.1f)
                SetRandomDestination();
        }
        else
            agent.SetDestination(playerTransform.position);
    }

    private void SetRandomDestination()
    {
        var newDestination = Random.Range(0, 2) == 0 ? startPosition : endPosition;

        agent.SetDestination(newDestination.position);
    }

    private void ReturnToPath() => isPlayerInSight = false;
}
