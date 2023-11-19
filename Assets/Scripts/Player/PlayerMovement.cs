using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private float xInput;
    private float yInput;

    private NavMeshAgent agent;

    private void Start() => agent = GetComponent<NavMeshAgent>();

    private void Update() => MoveAgent();

    private void MoveAgent()
    {
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

    public void SetHorizontalInput(float value) => xInput = value;

    public void SetMobileVerticalInput(float value) => yInput = value;
}
