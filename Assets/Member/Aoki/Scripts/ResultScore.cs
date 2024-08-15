using UnityEngine;
using UnityEngine.UI;

public class ResultScoreDisplay : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    void Start()
    {
        // スコアを取得して表示
        int finalScore = ScoreManager.Instance.GetScore();
        scoreText.text = "スコア: " + finalScore.ToString();

        // 必要であればスコアをリセット
        ScoreManager.Instance.ResetScore();
    }
}
