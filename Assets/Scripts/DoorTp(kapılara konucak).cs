using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportDoor : MonoBehaviour
{
    public AudioClip successClip;
    public AudioClip failClip;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerKeyHolder keyHolder = other.GetComponent<PlayerKeyHolder>();
        if (keyHolder != null && keyHolder.hasKey)
        {
            keyHolder.hasKey = false;

            if (successClip != null)
            {
                audioSource.PlayOneShot(successClip);
            }

            Debug.Log("Kapı açıldı, 3 saniye sonra sonraki sahneye geçiliyor...");
            Invoke("LoadNextScene", 3f); // 3 saniye delay
        }
        else
        {
            if (failClip != null)
            {
                audioSource.PlayOneShot(failClip);
            }

            Debug.Log("Kapı kilitli, anahtar yok!");
        }
    }

    private void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
