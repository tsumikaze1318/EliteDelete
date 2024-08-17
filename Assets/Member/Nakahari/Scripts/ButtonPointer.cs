using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPointer : MonoBehaviour
{
    private RectTransform _rectTransform;
    [SerializeField]
    private Vector3 _vec3;
    private Vector3 _orignalScale;

    private Button _button;

    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _orignalScale = _rectTransform.localScale;
    }

    public void OnPointerDown()
    {
        _rectTransform.localScale = _vec3;
    }

    public void OnPointerUp()
    {
        _rectTransform.localScale = _orignalScale;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
