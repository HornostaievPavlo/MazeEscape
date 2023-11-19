using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform startPosition;
    public Transform endPosition;

    private NavMeshAgent agent;

    private Transform playerInSight;

    private bool isPlayerInSight;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetRandomDestination();

        isPlayerInSight = false;

        EventsHandler.PlayerGotInSight.AddListener(StartPlayerFollowing);
        EventsHandler.PlayerLostFromSight.AddListener(ReturnToPath);
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
            agent.SetDestination(playerInSight.position);
    }

    private void SetRandomDestination()
    {
        var newDestination = Random.Range(0, 2) == 0 ? startPosition : endPosition;

        agent.SetDestination(newDestination.position);
    }

    private void StartPlayerFollowing(Transform target)
    {
        isPlayerInSight = true;

        playerInSight = target;
    }

    private void ReturnToPath() => isPlayerInSight = false;
}
