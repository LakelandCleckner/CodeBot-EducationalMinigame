using UnityEngine;

public class ForceField : MonoBehaviour
{
    private PlayerController player;
    private Collider2D col;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        if (player == null)
        {
            Debug.LogError("PlayerController not found! Ensure it’s in the scene.");
        }
        col = GetComponent<Collider2D>();
        if (col == null)
        {
            Debug.LogError("No Collider2D found on ForceField!");
        }
        col.enabled = true; // Ensure collider is enabled at start
    }

    void Update()
    {
        if (player != null && col != null)
        {
            col.enabled = !player.canPassForceField; // Enable collider when false, disable when true
            Debug.Log("ForceField collider enabled: " + col.enabled + " (canPassForceField: " + player.canPassForceField + ")");
        }
    }
}