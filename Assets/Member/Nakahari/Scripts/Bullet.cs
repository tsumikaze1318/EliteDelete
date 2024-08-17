using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool _enabled = false;
    private Renderer _renderer;
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }
    void Update()
    {
        if (!_enabled && _renderer.isVisible)
            _enabled = true;
        if (_enabled && !_renderer.isVisible)
            Destroy(gameObject);
    }
}
