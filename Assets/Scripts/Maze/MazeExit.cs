using UnityEngine;

public class MazeExit : MonoBehaviour
{
    private StateMachine stateMachine;

    private void OnTriggerEnter(Collider other)
    {
        bool isPlayerHit = other.gameObject.TryGetComponent(out PlayerMovement _);

        //if (isPlayerHit) 
            //stateMachine.SetState(new LevelFinishedState());
    }
}
