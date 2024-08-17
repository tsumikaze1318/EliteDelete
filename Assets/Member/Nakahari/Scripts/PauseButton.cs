using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    private Canvas _pauseCanvas;
    private Player _pl;

    private void Start()
    {
        _pauseCanvas = GetComponent<Canvas>();
        _pl = GetComponentInParent<Player>();
    }

    public void OnRestartButton()
    {
        SE.Instance.PlaySe(SEType.SE2);
        SceneFader.Instance.FadeToScene("Main",BGMType.BGM2,RandomState.Null,RandomSEType.Null);
    }

    public void OnTitleButton()
    {
        SE.Instance.PlaySe(SEType.SE2);
        SceneFader.Instance.FadeToScene("Title", BGMType.BGM1, RandomState.Null, RandomSEType.Null);
    }

    public void OnBackButton()
    {
        SE.Instance.PlaySe(SEType.SE2);
        _pl._isPause = false;
        _pauseCanvas.enabled = false;
        Time.timeScale = 1;
    }
}
