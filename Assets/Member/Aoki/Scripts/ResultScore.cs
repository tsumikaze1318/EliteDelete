using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    void Start()
    {
        // スコアを取得して表示
        int finalScore = ScoreManager.Instance.GetScore();
        scoreText.text = "スコア: " + finalScore.ToString();

        // 必要であればスコアをリセット
        ScoreManager.Instance.ResetScore();
    }
}
