using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FallResetManager : MonoBehaviour
{
    public Transform startPoint;
    public float fallThreshold = -20f;
    public GameObject gameOverPanel;        
    public AudioClip deathSound;
    private AudioSource audioSource;

    private bool isGameOver = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Hide the Game Over panel when the game starts
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (transform.position.y < fallThreshold && !isGameOver)
        {
            TriggerGameOver();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") && !isGameOver)
        {
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        isGameOver = true;

        // Stop the background music
        AudioSource bgm = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        if (bgm != null)
        {
            bgm.Stop();
        }

        // Play death sound
        if (deathSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(deathSound);
        }

        // Show Game Over Panel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }
}
