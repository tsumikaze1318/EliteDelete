using UnityEngine;

public class SE : MonoBehaviour
{
    public AudioClip[] seClips;  // SE �̔z��
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (seClips.Length > 0)
        {
            // 3 �� SE �̒����烉���_���� 1 ���Đ�
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
