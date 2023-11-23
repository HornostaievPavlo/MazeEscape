using UnityEngine;

public class MazeExit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        bool isPlayerHit = other.gameObject.TryGetComponent(out PlayerMovement _);

        if (isPlayerHit)
            EventsHandler.OnLevelFinished();
    }
}
