using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        bool isPlayerHit = collision.gameObject.TryGetComponent(out PlayerMovement _);

        if (isPlayerHit)
            Destroy(gameObject);
    }
}
