using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBlock : MonoBehaviour
{
    // Optional: Assign a respawn point in the Inspector
    public Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bean"))
        {
            Debug.Log("You touched the kill block!");

            if (respawnPoint != null)
            {
                // Move the player to the respawn point
                other.transform.position = respawnPoint.position;
            }
            else
            {
                // If no respawn point is set, destroy the player
                Destroy(other.gameObject);
            }
        }
    }
}

