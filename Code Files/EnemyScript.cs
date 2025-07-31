using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip hitSound;
    public int damage = 1; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (hitSound != null)
            {
                AudioSource.PlayClipAtPoint(hitSound, transform.position);
            }

            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }

    private void DestroyEnemy()
    {
        Renderer enemyRenderer = GetComponent<Renderer>();
        Collider enemyCollider = GetComponent<Collider>();
        if (enemyRenderer != null) enemyRenderer.enabled = false;
        if (enemyCollider != null) enemyCollider.enabled = false;

        // Delayed destruction of enemies
        Destroy(gameObject, 0.5f);  // Destroy the enemy after 0.5 seconds
    }
}
