using UnityEngine;

public class SilverCoin : MonoBehaviour
{
    public AudioClip collectSound;
    public float rotationSpeed = 100f;

    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gold coin picked up and ready for destruction");

            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(2);
            }
            else
            {
                Debug.LogWarning("ScoreManager instance is not found!");
            }

            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;

            // Delayed destruction
            Destroy(gameObject, 0.5f);  // Destroy after 0.5 seconds
        }
    } 
}