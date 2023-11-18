using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private Transform pathStartPosition;
    public Transform PathStartPosition
    {
        get { return pathStartPosition; }
        set { pathStartPosition = value; }
    }

    [SerializeField]
    private Transform pathEndPosition;
    public Transform PathEndPosition
    {
        get { return pathEndPosition; }
        set
        {
            pathEndPosition = value;
            currentTarget = pathEndPosition;
        }
    }

    private NavMeshAgent agent;

    private Transform currentTarget;

    private void Awake() => agent = GetComponent<NavMeshAgent>();

    private void Update()
    {
        if (pathStartPosition != null && pathEndPosition != null)
        {
            if (agent.remainingDistance < 0.1f)
            {
                SwitchTargets();
            }
        }
    }

    private void SetMovementTarget(Transform targetPosition)
    {
        currentTarget = targetPosition;

        agent.SetDestination(currentTarget.position);
    }

    private void SwitchTargets()
    {
        if (currentTarget == pathStartPosition)
        {
            SetMovementTarget(pathEndPosition);

            Debug.Log("Switched to end");
        }
        else
        {
            SetMovementTarget(pathStartPosition);

            Debug.Log("Switched to start");
        }
    }
}
