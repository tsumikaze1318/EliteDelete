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
        SceneFader.Instance.FadeToScene("Main");
    }

    public void OnTitleButton()
    {
        SceneFader.Instance.FadeToScene("Title");
    }

    public void OnBackButton()
    {
        _pl._isPause = false;
        _pauseCanvas.enabled = false;
        Time.timeScale = 1;
    }
}
