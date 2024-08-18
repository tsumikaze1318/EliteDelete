using UnityEngine;
using UnityEngine.UI;

public class GameScoreDisplay : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    void Update()
    {
        // 現在のスコアを取得して表示
        int currentScore = ScoreManager.Instance.GetScore();
        scoreText.text = "Score\n" + "<size=70>" + currentScore.ToString() + "</size>";
    }
}
