using UnityEngine;

public class EnemyDamageArea : MonoBehaviour
{
    [SerializeField]
    private float damageAmount;

    private void OnTriggerEnter(Collider other)
    {
        bool isPlayerHit = other.gameObject.TryGetComponent(out PlayerHealth playerHealth);

        if (isPlayerHit)
            EventsHandler.OnPlayerDamaged(damageAmount);
    }
}