using UnityEngine;
using TMPro;

public class GameScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Update()
    {
        // ���݂̃X�R�A���擾���ĕ\��
        int currentScore = ScoreManager.Instance.GetScore();
        scoreText.text = "Score: " + currentScore.ToString();
    }
}
