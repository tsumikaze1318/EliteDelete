using UnityEngine;
using UnityEngine.UI;

public class PG_BarController : MonoBehaviour
{
    public Slider progressSlider;  // �X���C�_�[�̎Q��
    public Transform player;       // �v���C���[�̎Q��
    public Transform goal;         // �S�[���̎Q��

    private float startX;
    private float goalX;

    void Start()
    {
        // �v���C���[�ƃS�[���̏����ʒu���擾
        startX = player.position.x;
        goalX = goal.position.x;

        // �X���C�_�[�̍ő�l��ݒ�
        progressSlider.maxValue = goalX - startX;
    }

    void Update()
    {
        // �v���C���[�̐i�s�x���v�Z���ăX���C�_�[�ɔ��f
        float playerProgress = player.position.x - startX;
        progressSlider.value = playerProgress;
    }
}

//    public Slider progressBar; // �i�s�x�o�[
//    public RectTransform playerIndicator; // �v���C���[�̈ʒu�C���W�P�[�^�[
//    public Transform player; // �v���C���[��Transform
//    public Transform startPoint; // �X�^�[�g�ʒu��Transform
//    public Transform bossPoint; // �{�X�ʒu��Transform

//    void Start()
//    {
//        // �Q�[���J�n���Ƀv���C���[�̏����ʒu��ݒ�
//        UpdateProgressBar();
//        UpdatePlayerIndicator();
//    }

//    //void Update()
//    //{
//    //    UpdateProgressBar();
//    //    UpdatePlayerIndicator();
//    //}

//    void Update()
//    {
//        UpdateProgressBar();
//        UpdatePlayerIndicator();

//        Debug.Log($"Slider Value: {progressBar.value}");
//        Debug.Log($"Indicator Position: {playerIndicator.anchoredPosition}");
//    }

//    void UpdateProgressBar()
//    {
//        // �X�^�[�g�ʒu�ƃ{�X�ʒu�̋���
//        float totalDistance = Vector2.Distance(startPoint.position, bossPoint.position);
//        // �X�^�[�g�ʒu�ƃv���C���[�ʒu�̋���
//        float playerDistance = Vector2.Distance(startPoint.position, player.position);

//        // �i�s�x��0����1�͈̔͂Ōv�Z
//        float progress = Mathf.Clamp(playerDistance / totalDistance, 0, 1);  // 0����1�ɐ���
//        progressBar.value = progress;
//    }

//    //void UpdateProgressBar()
//    //{
//    //    // �X�^�[�g�ʒu�ƃ{�X�ʒu�̋���
//    //    float totalDistance = Vector2.Distance(startPoint.position, bossPoint.position);
//    //    // �X�^�[�g�ʒu�ƃv���C���[�ʒu�̋���
//    //    float playerDistance = Vector2.Distance(startPoint.position, player.position);

//    //    // �i�s�x��0����1�͈̔͂Ōv�Z
//    //    float progress = playerDistance / totalDistance;
//    //    progressBar.value = progress;
//    //}

//    void UpdatePlayerIndicator()
//    {
//        // Slider�̕����擾
//        float progressBarWidth = progressBar.GetComponent<RectTransform>().rect.width;

//        // Slider��value�Ɋ�Â��ăC���W�P�[�^�[�̈ʒu���v�Z
//        float indicatorPositionX = Mathf.Clamp(progressBarWidth * progressBar.normalizedValue, 0, progressBarWidth);

//        // �v���C���[�C���W�P�[�^�[�̈ʒu���X�V
//        playerIndicator.anchoredPosition = new Vector2(indicatorPositionX, playerIndicator.anchoredPosition.y);
//    }

//}
