using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform goal;
    [SerializeField] private Stage stage;
    [SerializeField] private Slider slider;
    [SerializeField] private Image fillArea;
    [SerializeField] private GameObject handleObject;
    [SerializeField] private GameObject kumoObject;
    [SerializeField] private SpriteRenderer normalBack;
    [SerializeField] private SpriteRenderer normalBack1;
    [SerializeField] private SpriteRenderer normalBack2;
    [SerializeField] private SpriteRenderer normalBack3;
    [SerializeField] private SpriteRenderer bossBack;
    [SerializeField] private SpriteRenderer bossBack1;
    [SerializeField] private SpriteRenderer bossBack2;
    [SerializeField] private SpriteRenderer bossBack3;

    private Color normalColor = new Color(0.93f, 0.62f, 0.74f);  // ノーマルステージの色 (#ED9EBE)
    private Color bossColor = new Color(0.62f, 0.79f, 0.92f);    // ボスステージの色 (#9FC9EB)

    private float startX;
    private float goalX;

    private float transitionSpeed = 1.0f;

    public enum Stage
    {
        Normal,
        Boss
    }
    void Start()
    {
        startX = player.position.x;
        goalX = goal.position.x;
        slider.maxValue = goalX - startX;
        SetNormalBackgroundAlpha(1.0f);
        SetBossBackgroundAlpha(0);
    }

    void Update()
    {
        float playerProgress = player.position.x - startX;
        slider.value = playerProgress;
        if (slider.value >= 100)
        {
            stage = Stage.Boss;
        }

        if (stage == Stage.Normal)
        {
            fillArea.color = normalColor;
            handleObject.SetActive(true);
            kumoObject.SetActive(true);
            SetNormalBackgroundAlpha(1.0f);
            SetBossBackgroundAlpha(0);
        }
        else if (stage == Stage.Boss)
        {
            fillArea.color = bossColor;
            handleObject.SetActive(false);
            kumoObject.SetActive(false);
            FadeOutNormalBack();
            SetBossBackgroundAlpha(1.0f);
        }
    }

    private void FadeOutNormalBack()
    {
        FadeOutSprites(normalBack, normalBack1, normalBack2, normalBack3);
    }

    void FadeOutSprites(params SpriteRenderer[] sprites)
    {
        foreach (var sprite in sprites)
        {
            Color color = sprite.color;
            if (color.a > 0)
            {
                color.a -= Time.deltaTime * transitionSpeed;     // α値を徐々に減少
                sprite.color = color;
            }
        }
    }

    void SetNormalBackgroundAlpha(float alpha)
    {
        SetSpritesAlpha(alpha, normalBack, normalBack1, normalBack2, normalBack3);
    }

    void SetBossBackgroundAlpha(float alpha)
    {
        SetSpritesAlpha(alpha, bossBack, bossBack1, bossBack2, bossBack3);
    }

    void SetSpritesAlpha(float alpha, params SpriteRenderer[] sprites)
    {
        foreach (var sprite in sprites)
        {
            Color color = sprite.color;
            sprite.color = new Color(color.r, color.g, color.b, alpha);
        }
    }
}