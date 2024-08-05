using UnityEngine;
using UnityEngine.UI;

public class PG_BarController : MonoBehaviour
{
    public Slider progressBar; // �i�s�x�o�[
    public RectTransform playerIndicator; // �v���C���[�̈ʒu�C���W�P�[�^�[
    public Transform player; // �v���C���[��Transform
    public Transform startPoint; // �X�^�[�g�ʒu��Transform
    public Transform bossPoint; // �{�X�ʒu��Transform

    void Start()
    {
        // �Q�[���J�n���Ƀv���C���[�̏����ʒu��ݒ�
        UpdateProgressBar();
        UpdatePlayerIndicator();
    }

    void Update()
    {
        UpdateProgressBar();
        UpdatePlayerIndicator();
    }

    void UpdateProgressBar()
    {
        // �X�^�[�g�ʒu�ƃ{�X�ʒu�̋���
        float totalDistance = Vector2.Distance(startPoint.position, bossPoint.position);
        // �X�^�[�g�ʒu�ƃv���C���[�ʒu�̋���
        float playerDistance = Vector2.Distance(startPoint.position, player.position);

        // �i�s�x��0����1�͈̔͂Ōv�Z
        float progress = playerDistance / totalDistance;
        progressBar.value = progress;
    }

    void UpdatePlayerIndicator()
    {
        // �i�s�x�o�[�͈̔͂Ɋ�Â��ăv���C���[�C���W�P�[�^�[�̈ʒu���X�V
        Vector2 indicatorPosition = new Vector2(progressBar.fillRect.rect.width * progressBar.value, playerIndicator.anchoredPosition.y);
        playerIndicator.anchoredPosition = indicatorPosition;
    }
}
