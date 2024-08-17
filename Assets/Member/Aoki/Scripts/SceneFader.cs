using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public static SceneFader Instance;

    [SerializeField] private Canvas fadeCanvas; // フェード用Canvas
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1f;
    private bool _isFade = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // このオブジェクトをシーン間で保持
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(FadeIn());
    }

    public void FadeToScene(string GameScene, BGMType type, RandomState State,RandomSEType TypeSE)
    {
        if (_isFade) return;
        _isFade = true;
        StartCoroutine(FadeOut(GameScene));
        SE.Instance.PlayBgm(type);
        SE.Instance.RandomPlaySe(State, TypeSE);
    }

    private IEnumerator FadeIn()
    {
        fadeCanvas.enabled = true; // フェード用Canvasを有効にする
        float t = fadeDuration;
        while (t > 0f)
        {
            t -= Time.unscaledDeltaTime;
            float alpha = t / fadeDuration;
            SetAlpha(alpha);
            yield return null;
        }
        Time.timeScale = 1;
        SetAlpha(0f);
        fadeCanvas.enabled = false; // フェード用Canvasを無効にする
        _isFade = false;
    }

    private IEnumerator FadeOut(string GameScene)
    {
        
        fadeCanvas.enabled = true; // フェード用Canvasを有効にする
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.unscaledDeltaTime;
            float alpha = t / fadeDuration;
            SetAlpha(alpha);
            yield return null;
        }
        SetAlpha(1f);
        SceneManager.LoadScene(GameScene);
    }

    private void SetAlpha(float alpha)
    {
        Color color = fadeImage.color;
        color.a = alpha;
        fadeImage.color = color;
    }
}
