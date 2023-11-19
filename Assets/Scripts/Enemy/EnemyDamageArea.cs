using UnityEngine;

public class EnemyDamageArea : MonoBehaviour
{
    [SerializeField]
    private float damageAmount = 1f;

    [SerializeField]
    private float damageFrequency = 0.5f;

    private float sightTimer = 0f;

    private bool isPlayerInSight = false;

    private void Update()
    {
        if (!isPlayerInSight) return;

        DamagePlayerInSight();
    }

    private void DamagePlayerInSight()
    {
        sightTimer += Time.deltaTime;

        if (sightTimer >= damageFrequency)
        {
            EventsHandler.OnPlayerDamaged(damageAmount);

            sightTimer = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        bool isPlayerInsideDamageArea = other.gameObject.TryGetComponent(out PlayerHealth _);

        if (isPlayerInsideDamageArea)
            EventsHandler.OnPlayerGotInSight(other.transform);
    }

    private void OnTriggerStay(Collider other)
    {
        bool isPlayerInsideDamageArea = other.gameObject.TryGetComponent(out PlayerHealth _);

        if (isPlayerInsideDamageArea)
            isPlayerInSight = true;
    }

    private void OnTriggerExit(Collider other)
    {
        bool isPlayerInsideDamageArea = other.gameObject.TryGetComponent(out PlayerHealth _);

        if (isPlayerInsideDamageArea)
        {
            isPlayerInSight = false;
            sightTimer = 0f;

            EventsHandler.OnPlayerLostFromSight();
        }
    }
}
