using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
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
        {
            _enabled = true;
        }
        if (_enabled && !_renderer.isVisible)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _enabled = true;
        }
    }
}
