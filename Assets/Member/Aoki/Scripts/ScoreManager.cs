using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    private int score;

    void Awake()
    {
        // ���̃C���X�^���X�����݂���ꍇ�́A���̃C���X�^���X��j������
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // �V�[���ԂŃI�u�W�F�N�g��ێ�����
    }

    public void AddScore(string enemyTag, string colliderTag = null)
    {
        int scoreToAdd = 0;

        switch (enemyTag)
        {
            case "Enemy":
                scoreToAdd = 100;
                break;
            case "Enemy2":
                scoreToAdd = 300;
                break;
            case "Boss":
                if(colliderTag == "Bullet")
                {
                    scoreToAdd = 10;
                }
                else
                {
                    scoreToAdd = 3500;
                }
                break;
        }

        score += scoreToAdd;
        Debug.Log("Score: " + score);
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
    }
}
