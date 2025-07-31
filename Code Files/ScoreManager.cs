using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;  // Text component to display the score
    private int score = 0;      // Current score

    public static ScoreManager instance;  // Singleton instance of the ScoreManager

    public AudioSource backgroundMusic;
    public AudioClip victoryMusic;

    public GameObject victoryUI;
    public TMP_Text victoryText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);  // Destroy the duplicate instance
        }

        if (victoryUI != null)
        {
            victoryUI.SetActive(false);  // Hide victory UI at the start
        }
    }

    // Method to add score
    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();

        // Check if the player has met the winning condition
        if (score >= 25)
        {
            EndGame();  // End the game if the score reaches the target
        }
    }

    // Method to update the score display
    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();  // Update score text
        }
    }

    // Method to end the game and display victory
    void EndGame()
    {
        Debug.Log("Complete the goal");

        // Stop background music
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop();
        }

        // Play victory music
        if (victoryMusic != null)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = victoryMusic;
            audioSource.playOnAwake = false;
            audioSource.ignoreListenerPause = true;
            audioSource.volume = 0.4f;  // Set volume
            audioSource.Play();
        }

        // Show victory UI and set the victory message
        if (victoryUI != null)
        {
            victoryUI.SetActive(true);
            victoryText.text = "VICTORY!";
        }

        // Stop the game by freezing time
        Time.timeScale = 0;
    }

    // Method to reset the score
    public void ResetScore()
    {
        score = 0;  // Reset the score to 0
        UpdateScoreUI();  // Update the UI with the reset score
    }

    // Method to restart the game by resetting score and reloading the scene
    public void RestartGame()
    {
        ResetScore();

        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
