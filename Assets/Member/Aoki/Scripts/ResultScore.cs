using UnityEngine;
using UnityEngine.UI;

public class ResultScoreDisplay : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    void Start()
    {
        // �X�R�A���擾���ĕ\��
        int finalScore = ScoreManager.Instance.GetScore();
        scoreText.text = "�X�R�A: " + finalScore.ToString();

        // �K�v�ł���΃X�R�A�����Z�b�g
        ScoreManager.Instance.ResetScore();
    }
}
