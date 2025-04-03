using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebugUIController : MonoBehaviour
{
    public Slider jumpHeightSlider;
    public TMP_InputField jumpStatusInput;
    public Button closeButton;
    public TMP_Text jumpHeightValueText;
    public Toggle forceFieldToggle;
    public TMP_Text forceFieldValueText;
    public Slider movementSpeedSlider; // New slider for movement speed
    public TMP_Text movementSpeedValueText; // New text for displaying speed

    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        jumpHeightSlider.value = player.jumpHeight;
        jumpStatusInput.text = player.jumpStatus;
        forceFieldToggle.isOn = player.canPassForceField;
        movementSpeedSlider.value = player.movementSpeed; // Sync with initial value
        UpdateJumpHeightDisplay(player.jumpHeight);
        UpdateForceFieldDisplay(player.canPassForceField);
        UpdateMovementSpeedDisplay(player.movementSpeed);

        jumpHeightSlider.onValueChanged.AddListener(UpdateJumpHeight);
        jumpStatusInput.onValueChanged.AddListener(UpdateJumpStatus);
        forceFieldToggle.onValueChanged.AddListener(UpdateForceFieldStatus);
        movementSpeedSlider.onValueChanged.AddListener(UpdateMovementSpeed); // New listener
        closeButton.onClick.AddListener(CloseUI);
    }

    void UpdateJumpHeight(float value)
    {
        player.SetJumpHeight(value);
        UpdateJumpHeightDisplay(value);
    }

    void UpdateJumpStatus(string value)
    {
        player.SetJumpStatus(value);
    }

    void UpdateForceFieldStatus(bool value)
    {
        player.SetForceFieldStatus(value);
        UpdateForceFieldDisplay(value);
    }

    void UpdateMovementSpeed(float value)
    {
        player.SetMovementSpeed(value);
        UpdateMovementSpeedDisplay(value);
    }

    void UpdateJumpHeightDisplay(float value)
    {
        if (jumpHeightValueText != null)
            jumpHeightValueText.text = value.ToString("F1");
    }

    void UpdateForceFieldDisplay(bool value)
    {
        if (forceFieldValueText != null)
            forceFieldValueText.text = value.ToString();
    }

    void UpdateMovementSpeedDisplay(float value)
    {
        if (movementSpeedValueText != null)
            movementSpeedValueText.text = value.ToString("F1");
    }

    void CloseUI()
    {
        player.CloseUI();
    }
}