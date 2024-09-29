using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthField;
    [SerializeField] private TMP_Text _speedField;

    public string HealthName { get; private set; } = "Health";
    public string SpeedName { get; private set; } = "Speed";

    private void UpdateField(TMP_Text field, string name, float value) => field.text = name + ": " + value.ToString("F0");
    
    public void UpdateHealthField(float value) => _healthField.text = $"{HealthName}: {value.ToString("F0")}";
    
    public void UpdateSpeedField(float value) => _speedField.text = $"{SpeedName}: {value.ToString("F0")}";
}
