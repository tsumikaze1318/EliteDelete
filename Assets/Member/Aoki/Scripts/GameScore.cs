using UnityEngine;
using TMPro;

public class GameScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    void Update()
    {
        // ���݂̃X�R�A���擾���ĕ\��
        int currentScore = ScoreManager.Instance.GetScore();
        scoreText.text = "Score: " + currentScore.ToString();
    }
}
