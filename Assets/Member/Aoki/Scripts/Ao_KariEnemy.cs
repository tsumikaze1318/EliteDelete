using UnityEngine;
using UnityEngine.UI;

public class Ao_KariEnemy : MonoBehaviour
{
    public int health = 100;
    public Slider healthSlider;  // �{�X�X�N���v�g�ɕK�v

    void Start()
    {
        // �X���C�_�[�̏�����
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
            ScoreManager.Instance.AddScore("Boss", "Bullet");//Boss�X�N���v�g�ɒǉ�
            //TakeDamage(5);
            //Debug.Log("au-");
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;

        // �X���C�_�[���X�V
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
        ScoreManager.Instance.AddScore(gameObject.tag);//35P,����,Boss�ɒǉ�

        // �G���폜
        Destroy(gameObject);
        //SceneFader.Instance.FadeToScene("AoScoreScene");
    }
}
