using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebugUIController : MonoBehaviour
{
    public Slider jumpHeightSlider;
    public TMP_InputField jumpStatusInput;
    public Button closeButton;
    public TMP_Text jumpHeightValueText;
    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        jumpHeightSlider.value = player.jumpHeight;
        jumpStatusInput.text = player.jumpStatus;
        UpdateJumpHeightDisplay(player.jumpHeight);

        jumpHeightSlider.onValueChanged.AddListener(UpdateJumpHeight);
        jumpStatusInput.onValueChanged.AddListener(UpdateJumpStatus);
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

    void UpdateJumpHeightDisplay(float value)
    {
        if (jumpHeightValueText != null)
            jumpHeightValueText.text = value.ToString("F1");
    }

    void CloseUI()
    {
        player.CloseUI(); // Call PlayerController's method to sync state
    }
}