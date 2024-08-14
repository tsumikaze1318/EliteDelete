using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUI : MonoBehaviour
{
    private RectTransform _rectTransform;
    private Transform _target;
    [SerializeField]
    private Vector3 _offset;
    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _target = GetComponentInParent<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        RefreshPosition();
    }

    void RefreshPosition()
    {
        if (_target)
        {
            Vector2 screenPos = Camera.main.WorldToScreenPoint(_target.position + _offset);
            _rectTransform.position = screenPos;

        }
    }
}
