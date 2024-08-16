using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [Header("�݂����̏ꏊ�ƃS�[��")]

    [SerializeField] private Transform player;
    [SerializeField] private Transform goal;
    [SerializeField] private Stage stage;

    [Header("�X���C�_�[")]

    [SerializeField]
    [Tooltip("�݂����X���C�_�[")] private Slider slider;
    [SerializeField] private Image fillArea;
    [SerializeField] private GameObject handleObject;
    [SerializeField]
    [Tooltip("����������HP�X���C�_�[")]private Slider SuiHP;

    [Header("�w�i")]

    [SerializeField] private SpriteRenderer normalBack;
    [SerializeField] private SpriteRenderer normalBack1;
    [SerializeField] private SpriteRenderer normalBack2;
    [SerializeField] private SpriteRenderer normalBack3;
    [SerializeField] private GameObject kumoObject;
    [SerializeField] private SpriteRenderer bossBack;
    [SerializeField] private SpriteRenderer bossBack1;
    [SerializeField] private SpriteRenderer bossBack2;
    [SerializeField] private SpriteRenderer bossBack3;
    [SerializeField] private GameObject starObject;

    private Color normalColor = new Color(0.93f, 0.62f, 0.74f);  // �m�[�}���X�e�[�W�̐F (#ED9EBE)
    private Color bossColor = new Color(0.62f, 0.79f, 0.92f);    // �{�X�X�e�[�W�̐F (#9FC9EB)

    private float startX;
    private float goalX;

    private float transitionSpeed = 1.0f;


    // �����ǋL �Q�Ɛ�
    /*[SerializeField]
    private Player _pl;
    [SerializeField]
    private BossStatus _boss;*/

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
        //SetBossBackgroundAlpha(0);
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
            slider.gameObject.SetActive(true);
            handleObject.SetActive(true);
            kumoObject.SetActive(true);
            starObject.SetActive(false);
            SuiHP.gameObject.SetActive(false);
            SetNormalBackgroundAlpha(1.0f);
            //SetBossBackgroundAlpha(0);
        }
        else if (stage == Stage.Boss)
        {
            fillArea.color = bossColor;
            slider.gameObject.SetActive(false);
            handleObject.SetActive(false);
            kumoObject.SetActive(false);
            starObject.SetActive(true);
            SuiHP.gameObject.SetActive(true);
            FadeOutNormalBack();
            //SetBossBackgroundAlpha(1.0f);
        }
    }
    
    // �����ǋL �����Ń��U���g����

    /*private void result()
    {
        if (_pl.Hp <= 0)
        {
            if(slider.value < 100)
            {
                SceneFader.Instance.FadeToScene("");
            }
            else
            {
                SceneFader.Instance.FadeToScene("");
            }
        }
        if(_boss._hp <= 0)
        {
            SceneFader.Instance.FadeToScene("");
        }
    }*/

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
                color.a -= Time.deltaTime * transitionSpeed;     // ���l�����X�Ɍ���
                sprite.color = color;
            }
        }
    }

    void SetNormalBackgroundAlpha(float alpha)
    {
        SetSpritesAlpha(alpha, normalBack, normalBack1, normalBack2, normalBack3);
    }

    //void SetBossBackgroundAlpha(float alpha)
    //{
    //    SetSpritesAlpha(alpha, bossBack, bossBack1, bossBack2, bossBack3);
    //}

    void SetSpritesAlpha(float alpha, params SpriteRenderer[] sprites)
    {
        foreach (var sprite in sprites)
        {
            Color color = sprite.color;
            sprite.color = new Color(color.r, color.g, color.b, alpha);
        }
    }
}