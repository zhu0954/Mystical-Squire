using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;    // Reference to the player's transform
    public Vector3 offset;      // Offset from the player

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player transform is not assigned in CameraFollow script.");
            return;
        }

        // Set the initial offset based on the camera's current position relative to the player
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Update the camera's position to follow the player
            transform.position = player.position + offset;
        }
    }
}
