using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Start() => agent = GetComponent<NavMeshAgent>();

    private void Update() => MoveAgent();

    private void MoveAgent()
    {
        var xInput = Input.GetAxis("Horizontal");
        var yInput = Input.GetAxis("Vertical");

        if (xInput != 0 || yInput != 0)
        {
            var movementDirection = new Vector3(xInput, 0, yInput);

            var targetPosition = transform.position + movementDirection;

            agent.SetDestination(targetPosition);
        }
        else
        {
            agent.SetDestination(transform.position);
        }
    }
}
