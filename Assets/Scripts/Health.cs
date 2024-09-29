using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private UIController _uiController;

    public float HealthValue { get; private set; } = 0f;

    public void InitializeHealth(UIController uiController, float value)
    {
        _uiController = uiController;
        HealthValue = value;
        UpdateHealthUI();
    }

    public void IncreaseHealthValue(float value)
    {
        if ((HealthValue + value) > 0)
            HealthValue += value;
        else
            HealthValue = 0;

        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (_uiController is null)
        {
            Debug.Log("UI isn't linked");
            return;
        }

        _uiController.UpdateHealthField(HealthValue);
    }
}
