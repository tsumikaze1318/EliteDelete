using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public void OnGameStartButtonClicked()
    {
        SceneFader.Instance.FadeToScene("AoScene");
        Debug.Log("В╔Ве");
    }

    public void OnRuleButtonClicked()
    {
        SceneFader.Instance.FadeToScene("");
    }

    public void OnReStartButtonOnClicked()
    {
        SceneFader.Instance.FadeToScene("AoScene");
    }

    public void OnTitleBackClicled()
    {
        SceneFader.Instance.FadeToScene("AoTScene");
    }
}
