using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public void OnGameStartButtonClicked()
    {
        SceneFader.Instance.FadeToScene("Title");
        Debug.Log("�ɂ�");
    }

    public void OnRuleButtonClicked()
    {
        SceneFader.Instance.FadeToScene("");
    }
}
