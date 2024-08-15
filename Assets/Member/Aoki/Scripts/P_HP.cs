// PlayerHealth.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class P_HP : MonoBehaviour
{
    // SliderController��GameStage enum���g�p
    public SliderController.Stage stage;
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Health��0�ɂȂ����Ƃ��̏���
        if (currentHealth <= 0)
        {
            HandlePlayerDeath();
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            HandlePlayerDeath();
        }
    }

    private void HandlePlayerDeath()
    {
        switch (stage)
        {
            case SliderController.Stage.Normal:
                SceneManager.LoadScene("LoseScene1");
                break;
            case SliderController.Stage.Boss:
                SceneManager.LoadScene("LoseScene2");
                break;
        }
    }
}
