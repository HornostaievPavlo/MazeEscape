using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;

    private float currentHealth;

    public UnityEvent<float> PlayerHealthUpdated = new UnityEvent<float>();

    private void Start() => currentHealth = maxHealth;

    public void ModifyHealth(float amount)
    {
        currentHealth -= amount;

        float currentHealthPercent = currentHealth / maxHealth;

        PlayerHealthUpdated.Invoke(currentHealthPercent);

        if (currentHealth == 0)
        {
            EventsHandler.OnPlayerKilled();
            Destroy(gameObject);
        }
    }
}
