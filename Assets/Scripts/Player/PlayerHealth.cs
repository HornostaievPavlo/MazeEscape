using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;

        EventsHandler.PlayerDamaged.AddListener(ModifyHealth);
    }

    private void ModifyHealth(float amount)
    {
        currentHealth -= amount;

        float currentHealthPercent = currentHealth / maxHealth;

        EventsHandler.OnPlayerHealthUpdated(currentHealthPercent);

        if (currentHealth == 0)
        {
            Destroy(gameObject);
            EventsHandler.OnPlayerKilled();
        }
    }
}
