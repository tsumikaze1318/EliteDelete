using UnityEngine;

public class Ao_KariEnemy : MonoBehaviour
{
    public int health = 100;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage(50);
            Debug.Log("au-");
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            OnDefeated();
        }
    }

    void OnDefeated()
    {
        // スコアを追加
        ScoreManager.Instance.AddScore(gameObject.tag);

        // 敵を削除
        Destroy(gameObject);
        SceneFader.Instance.FadeToScene("AoScoreScene");
    }
}
