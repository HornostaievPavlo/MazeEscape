using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image gradientImage;

    [SerializeField]
    private Gradient gradient;

    [SerializeField]
    private float updateSpeed;

    private void Awake()
    {
        EventsHandler.PlayerHealthUpdated.AddListener(HandleHealthChange);

        gradientImage.color = gradient.Evaluate(1f);
    }

    private void HandleHealthChange(float percent)
    {
        StartCoroutine(ChangeToPercent(percent));
    }

    private IEnumerator ChangeToPercent(float percent)
    {
        float preChangePercent = gradientImage.fillAmount;

        float elapsedTime = 0f;

        while (elapsedTime < updateSpeed)
        {
            elapsedTime += Time.deltaTime;

            gradientImage.fillAmount = Mathf.Lerp(preChangePercent, percent, elapsedTime / updateSpeed);

            yield return null;
        }

        gradientImage.fillAmount = percent;

        gradientImage.color = gradient.Evaluate(gradientImage.fillAmount);
    }
}
