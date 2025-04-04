using UnityEngine;

public class PowerCell : MonoBehaviour
{
    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            player.CollectPowerCell();
            Destroy(gameObject);
        }
    }
}