using UnityEngine;

public class SE : MonoBehaviour
{
    public AudioClip[] seClips;  // SE ‚Ì”z—ñ
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (seClips.Length > 0)
        {
            // 3 ‚Â‚Ì SE ‚Ì’†‚©‚çƒ‰ƒ“ƒ_ƒ€‚Å 1 ‚Â‚ğÄ¶
            int randomIndex = Random.Range(0, seClips.Length);
            audioSource.clip = seClips[randomIndex];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("SE clips are not assigned.");
        }
    }
}
