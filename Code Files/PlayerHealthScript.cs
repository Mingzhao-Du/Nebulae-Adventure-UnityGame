using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public Image[] healthIcons;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public AudioClip collectSound;
    public AudioClip deathSound;
    public GameObject gameOverPanel;
    public Button restartButton;
    private AudioSource audioSource;
    private AudioSource backgroundMusicSource;

    void Start()
    {
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
        backgroundMusicSource = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        UpdateHealthUI();  // Update the health icon when the game starts

        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame); // Bind the click event of the restart game button
        }
    }

    public void AddHealth(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        UpdateHealthUI();  // Update HP icon
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        for (int i = 0; i < healthIcons.Length; i++)
        {
            healthIcons[i].sprite = i < currentHealth ? fullHeart : emptyHeart;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Heart"))
        {
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }
            AddHealth(1);  // Add blood when eating health packets
            Destroy(other.gameObject);  // Destroy health packets
        }
    }

    void Die()
    {
        Debug.Log("Player died.");
        if (deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);  // Play death sound
        }
        if (backgroundMusicSource != null)
        {
            backgroundMusicSource.Stop();  // Stop the background music
        }
        gameOverPanel.SetActive(true);  // Show Game Over interface
        Time.timeScale = 0;  // pause the game
    }

    // Ways to restart the game
    void RestartGame()
    {
        Time.timeScale = 1;  // Restore game time
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Reload the current scene
    }
}