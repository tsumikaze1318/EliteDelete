using UnityEngine;

public class SE : MonoBehaviour
{
    public AudioClip[] seClips;  // SE の配列
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (seClips.Length > 0)
        {
            // 3 つの SE の中からランダムで 1 つを再生
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
