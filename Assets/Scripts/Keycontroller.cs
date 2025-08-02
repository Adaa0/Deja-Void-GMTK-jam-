using UnityEngine;

public class PlayerKeyHolder : MonoBehaviour
{
    public bool hasKey = false;
    [SerializeField] private AudioClip pickSoundClip;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            audioSource.clip = pickSoundClip;
            audioSource.Play();
            hasKey = true;
            Destroy(other.gameObject);
        }
    }
}
