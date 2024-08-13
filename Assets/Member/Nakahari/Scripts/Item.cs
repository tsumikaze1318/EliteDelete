using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField]
    private float _itemSpeed;

    private bool _enabled = false;
    private Renderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponentInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = new Vector2(-_itemSpeed, 0);
        if (!_enabled && _renderer.isVisible)
            _enabled = true;
        if (_enabled && !_renderer.isVisible)
            Destroy(gameObject);
    }
}
