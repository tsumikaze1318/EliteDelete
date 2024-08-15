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
        // �X�R�A��ǉ�
        ScoreManager.Instance.AddScore(gameObject.tag);

        // �G���폜
        Destroy(gameObject);
        SceneFader.Instance.FadeToScene("AoScoreScene");
    }
}
