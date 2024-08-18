using UnityEngine;
using UnityEngine.UI;

public class GameScoreDisplay : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    void Update()
    {
        // ���݂̃X�R�A���擾���ĕ\��
        int currentScore = ScoreManager.Instance.GetScore();
        scoreText.text = "Score\n" + "<size=70>" + currentScore.ToString() + "</size>";
    }
}
