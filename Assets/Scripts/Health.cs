using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private UIController _uiController;

    public float HealthValue { get; private set; }


    public event Action<float> OnHealthChanged;

    public Health(UIController uiController, float value)
    {
        _uiController = uiController;
        HealthValue = value;
        UpdateHealthUI();
    }

    public void IncreaseHealthValue(float value)
    {
        HealthValue += value;
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        _uiController.UpdateHealthField(HealthValue);
    }
}
