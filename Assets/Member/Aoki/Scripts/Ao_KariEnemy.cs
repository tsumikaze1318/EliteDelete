using UnityEngine;
using UnityEngine.UI;

public class Ao_KariEnemy : MonoBehaviour
{
    public int health = 100;
    public Slider healthSlider;  // ボススクリプトに必要

    void Start()
    {
        // スライダーの初期化
        if (healthSlider != null)
        {
            healthSlider.maxValue = health;
            healthSlider.value = health;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            ScoreManager.Instance.AddScore("Boss", "Bullet");//Bossスクリプトに追加
            //TakeDamage(5);
            //Debug.Log("au-");
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;

        // スライダーを更新
        if (healthSlider != null)
        {
            healthSlider.value = health;
        }

        if (health <= 0)
        {
            OnDefeated();
        }
    }

    void OnDefeated()
    {
        ScoreManager.Instance.AddScore(gameObject.tag);//35P,金縄,Bossに追加

        // 敵を削除
        Destroy(gameObject);
        //SceneFader.Instance.FadeToScene("AoScoreScene");
    }
}
