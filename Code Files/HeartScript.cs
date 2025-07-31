using UnityEngine;

public class HeartScript : MonoBehaviour
{
    public AudioClip collectSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Get PlayerHealth Script
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                // Call the player's AddHealth method
                playerHealth.AddHealth(1);
            }
            else
            {
                Debug.LogWarning("PlayerHealth script not found on Player object!");
            }

            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            // Destroy Health packets
            Destroy(gameObject);
        }
    }
}
