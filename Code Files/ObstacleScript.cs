using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public AudioClip hitSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (hitSound != null)
            {
                audioSource.clip = hitSound;
                audioSource.Play();
            }
        }
    }
}
