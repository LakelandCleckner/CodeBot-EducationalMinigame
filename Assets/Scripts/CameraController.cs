using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    public float xOffset = 2f; // Positive value shifts camera right, negative shifts left

    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
    }

    void LateUpdate()
    {
        // Apply the offset to the target's x position
        transform.position = new Vector3(target.position.x + xOffset, target.position.y, transform.position.z);
    }
}