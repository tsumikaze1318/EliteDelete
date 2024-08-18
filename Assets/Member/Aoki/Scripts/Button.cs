using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public void OnGameStartButtonClicked()
    {
        SceneFader.Instance.FadeToScene("Main",BGMType.BGM2, RandomState.Start, RandomSEType.Start);
        Debug.Log("В╔Ве");
    }

    public void OnResultTitleBackButton()
    {
        SceneFader.Instance.FadeToScene("Title", BGMType.BGM1, RandomState.Null, RandomSEType.Null);
        SE.Instance.PlaySe(SEType.SE7);
    }

    public void OnTitleBackClicled()
    {
        SceneFader.Instance.FadeToScene("Title",BGMType.BGM1,RandomState.Null,RandomSEType.Null);
        SE.Instance.PlaySe(SEType.SE6);
    }
}
