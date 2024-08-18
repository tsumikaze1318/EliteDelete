using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    private Canvas _pauseCanvas;
    [SerializeField]
    private Player _pl;

    private void Start()
    {
        _pauseCanvas = GetComponent<Canvas>();
    }

    public void OnRestartButton()
    {
        SceneFader.Instance.FadeToScene("Main",BGMType.BGM2,RandomState.Null,RandomSEType.Null, SEType.SE2);
        ScoreManager.Instance.ResetScore();
    }

    public void OnTitleButton()
    {
        SceneFader.Instance.FadeToScene("Title", BGMType.BGM1, RandomState.Null, RandomSEType.Null, SEType.SE2);
        ScoreManager.Instance.ResetScore();
    }

    public void OnBackButton()
    {
        SE.Instance.PlaySe(SEType.SE2);
        _pl._isPause = false;
        _pauseCanvas.enabled = false;
        Time.timeScale = 1;
    }
}
