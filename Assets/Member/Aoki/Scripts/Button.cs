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

    public void OnTitleBackClicled()
    {
        SE.Instance.PlaySe(SEType.SE2);
        SceneFader.Instance.FadeToScene("Title",BGMType.BGM1,RandomState.Null,RandomSEType.Null);
    }
}
