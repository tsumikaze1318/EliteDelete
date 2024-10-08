// PlayerHealth.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class P_HP : MonoBehaviour
{
    // SliderControllerのGameStage enumを使用
    public SliderController.Stage stage;
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Healthが0になったときの処理
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
