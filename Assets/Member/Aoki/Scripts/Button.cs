using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public void OnGameStartButtonClicked()
    {
        SceneFader.Instance.FadeToScene("Main");
        SE.Instance.RandomPlaySe(RandomState.Start, RandomSEType.Start);
        Debug.Log("�ɂ�");
    }

    public void OnTitleBackClicled()
    {
        SceneFader.Instance.FadeToScene("Title");
    }
}
