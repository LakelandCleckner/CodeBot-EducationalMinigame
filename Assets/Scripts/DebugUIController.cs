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
    public Slider movementSpeedSlider;
    public TMP_Text movementSpeedValueText;
    public TMP_Text powerCellsText;

    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        jumpHeightSlider.value = player.jumpHeight;
        jumpStatusInput.text = player.jumpStatus;
        forceFieldToggle.isOn = player.canPassForceField;
        movementSpeedSlider.value = player.movementSpeed;
        UpdateJumpHeightDisplay(player.jumpHeight);
        UpdateForceFieldDisplay(player.canPassForceField);
        UpdateMovementSpeedDisplay(player.movementSpeed);
        UpdatePowerCellsDisplay(player.powerCellsCollected);

        jumpHeightSlider.onValueChanged.AddListener(UpdateJumpHeight);
        jumpStatusInput.onValueChanged.AddListener(UpdateJumpStatus);
        forceFieldToggle.onValueChanged.AddListener(UpdateForceFieldStatus);
        movementSpeedSlider.onValueChanged.AddListener(UpdateMovementSpeed);
        closeButton.onClick.AddListener(CloseUI);
    }

    public void RefreshUI()
    {
        jumpHeightSlider.value = player.jumpHeight;
        jumpStatusInput.text = player.jumpStatus;
        forceFieldToggle.isOn = player.canPassForceField;
        movementSpeedSlider.value = player.movementSpeed;
        UpdateJumpHeightDisplay(player.jumpHeight);
        UpdateForceFieldDisplay(player.canPassForceField);
        UpdateMovementSpeedDisplay(player.movementSpeed);
        UpdatePowerCellsDisplay(player.powerCellsCollected);
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

    public void UpdatePowerCellsDisplay(int value)
    {
        if (powerCellsText != null)
        {
            powerCellsText.text = value.ToString();
            Debug.Log("Updated powerCellsText to: " + powerCellsText.text);
        }
        else
        {
            Debug.LogWarning("powerCellsText is not assigned in DebugUIController!");
        }
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