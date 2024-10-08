using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [Header("みこちの場所とゴール")]

    [SerializeField] private Transform cam;
    [SerializeField] private Transform goal;
    [SerializeField] private Stage stage;
    [SerializeField] private GameObject SuichanName;

    [Header("スライダー")]

    [SerializeField]
    [Tooltip("みこちスライダー")] private Slider slider;
    [SerializeField] private Image fillArea;
    [SerializeField] private GameObject handleObject;
    [SerializeField]
    [Tooltip("すいちゃんのHPスライダー")]private Slider SuiHP;

    [Header("背景")]

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

    private Color normalColor = new Color(0.93f, 0.62f, 0.74f);  // ノーマルステージの色 (#ED9EBE)
    private Color bossColor = new Color(0.62f, 0.79f, 0.92f);    // ボスステージの色 (#9FC9EB)

    private float startX;
    private float goalX;

    private float transitionSpeed = 1.0f;
    private bool BossSE = false;
    private bool fade = false;

    public bool SEse = false;

    // 中張追記 参照先
    [SerializeField]
    private Player _pl;
    [SerializeField]
    private BossStatus _boss;

    private bool _addScore = false;

    public enum Stage
    {
        Normal,
        Boss
    }
    void Start()
    {
        SEse = true;
        _addScore = false;
        startX = cam.position.x;
        goalX = goal.position.x;
        slider.maxValue = goalX - startX;
        SetNormalBackgroundAlpha(1.0f);
        //SetBossBackgroundAlpha(0);
        if(stage == Stage.Normal)
        {
            SE.Instance.RandomPlaySe(RandomState.InGame, RandomSEType.InGame);
        }
    }

    void Update()
    {
        if (!fade)
        {
            result();
        }
        float playerProgress = cam.position.x - startX;
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
            SuichanName.gameObject.SetActive(false);
            SetNormalBackgroundAlpha(1.0f);
            //SetBossBackgroundAlpha(0);
            //SE.Instance.RandomPlaySe(RandomState.InGame,RandomSEType.InGame);
        }
        else if (stage == Stage.Boss)
        {
            fillArea.color = bossColor;
            slider.gameObject.SetActive(false);
            handleObject.SetActive(false);
            kumoObject.SetActive(false);
            starObject.SetActive(true);
            SuiHP.gameObject.SetActive(true);
            SuichanName.gameObject.SetActive(true);
            FadeOutNormalBack();
            //SetBossBackgroundAlpha(1.0f);
            if (!BossSE)
            {
                BossSE = true;
                SE.Instance.StopBgm();
                SE.Instance.PlayBgm(BGMType.BGM5);
                StartCoroutine(SuiSE());

            }
        }
    }

    IEnumerator SuiSE()
    {
        SE.Instance.PlaySe(SEType.SE3);
        yield return new WaitWhile(() => SE.Instance.PassAudioSource().isPlaying);
        SE.Instance.PlaySe(SEType.SE4);
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime;
            float alpha = t / 1;
            SetAlpha(alpha);
            yield return null;
        }
        yield return new WaitWhile(() => SE.Instance.PassAudioSource().isPlaying);
        SetAlpha(1f);
        SEse = false;
        SE.Instance.PlaySe(SEType.SE8);
    }

    private void SetAlpha(float alpha)
    {
        foreach(SpriteRenderer sr in _boss._sprite)
        {
            Color color = sr.color;
            color.a = alpha;
            sr.color = color;
        }
    }


    // 中張追記 条件でリザルト分岐

    private void result()
    {
        if (_pl.Hp <= 0)
        {
            fade = true;
            if(slider.value < 100)
            {
                SceneFader.Instance.FadeToScene("Lose1",BGMType.BGM4,RandomState.GameOver,RandomSEType.GameOver, SEType.Null);
            }
            else
            {
                SceneFader.Instance.FadeToScene("Lose2",BGMType.BGM4,RandomState.GameOver, RandomSEType.GameOver, SEType.Null);
            }
        }
        if(_boss._hp <= 0)
        {
            fade = true;
            if (!_addScore)
            {
                _addScore = true;
                ScoreManager.Instance.AddScore("Boss", "null");
            }
            SceneFader.Instance.FadeToScene("Result",BGMType.BGM3,RandomState.Claer,RandomSEType.Claer, SEType.Null);
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