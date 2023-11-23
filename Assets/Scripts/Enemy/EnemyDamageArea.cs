using UnityEngine;

public class EnemyDamageArea : MonoBehaviour
{
    [SerializeField]
    private float damageAmount = 1f;

    [SerializeField]
    private float damageFrequency = 0.5f;

    private EnemyMovement enemyMovement;

    private float sightTimer = 0f;

    private void Awake() => enemyMovement = GetComponentInParent<EnemyMovement>();

    private void OnTriggerEnter(Collider other)
    {
        bool isPlayerHit = other.gameObject.TryGetComponent(out PlayerHealth _);

        if (isPlayerHit)
        {
            enemyMovement.isPlayerInSight = true;
            enemyMovement.playerTransform = other.transform;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        bool isPlayerInsideDamageArea = other.gameObject.TryGetComponent(out PlayerHealth _);

        if (isPlayerInsideDamageArea)
        {
            var playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            DamagePlayerInSight(playerHealth);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        bool hasPlayerExited = other.gameObject.TryGetComponent(out PlayerHealth _);

        if (hasPlayerExited)
        {
            sightTimer = 0f;

            enemyMovement.isPlayerInSight = false;
        }
    }

    private void DamagePlayerInSight(PlayerHealth playerHealth)
    {
        sightTimer += Time.deltaTime;

        if (sightTimer >= damageFrequency)
        {
            playerHealth.ModifyHealth(damageAmount);

            sightTimer = 0f;
        }
    }
}
