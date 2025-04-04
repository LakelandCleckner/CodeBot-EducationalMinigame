using UnityEngine;

public class Portal : MonoBehaviour
{
    private PlayerController player;
    private Collider2D col;
    private SpriteRenderer spriteRenderer;
    public Sprite inactiveSprite;
    public Sprite activeSprite;
    public GameObject winPanel;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        if (player == null)
        {
            Debug.LogError("PlayerController not found!");
        }
        col = GetComponent<Collider2D>();
        if (col == null)
        {
            Debug.LogError("No Collider2D found on Portal!");
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("No SpriteRenderer found on Portal!");
        }
        if (winPanel != null) winPanel.SetActive(false);

        col.enabled = false;
        spriteRenderer.sprite = inactiveSprite;
    }

    void Update()
    {
        if (player != null && player.powerCellsCollected >= player.powerCellsRequired)
        {
            col.enabled = true;
            spriteRenderer.sprite = activeSprite;
        }
        else
        {
            col.enabled = false;
            spriteRenderer.sprite = inactiveSprite;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() && col.enabled)
        {
            if (winPanel != null)
            {
                winPanel.SetActive(true);
                Time.timeScale = 0f; // Pause the game
                Cursor.visible = true; // Enable the cursor
                Cursor.lockState = CursorLockMode.None; // Unlock the cursor
            }
        }
    }
}