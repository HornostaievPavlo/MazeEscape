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

    private void Update() => CheckState();

    private void ModifyHealth(float amount)
    {
        currentHealth -= amount;

        float currentHealthPercent = currentHealth / maxHealth;

        EventsHandler.OnPlayerHealthUpdated(currentHealthPercent);
    }

    private void CheckState()
    {
        if (currentHealth == 0)
        {

        }
    }
}
