using UnityEngine;
using TMPro;

public class GameScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Update()
    {
        // 現在のスコアを取得して表示
        int currentScore = ScoreManager.Instance.GetScore();
        scoreText.text = "Score: " + currentScore.ToString();
    }
}
