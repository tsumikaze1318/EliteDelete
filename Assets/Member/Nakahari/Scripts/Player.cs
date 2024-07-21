using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 _move = Vector2.zero;
    [Header("プレイヤーのステータス")]
    [SerializeField]
    public int _hp;
    [SerializeField]
    private float _moveSpeed;

    private Rigidbody2D _rb;

    [Header("弾のステータス")]
    [SerializeField]
    [Tooltip("弾の速度")] private float _bulletSpeed;
    [SerializeField]
    [Tooltip("発射間隔")] private float _interval;
    [SerializeField]
    [Tooltip("バーストにするかどうか")] private bool _burst;
    [SerializeField]
    [Tooltip("バースト間隔")] private float _burstInterval;
    [SerializeField]
    [Tooltip("バースト回数")] private int _maxBulletCount;


    [Header("--------------------------------")]
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private GameObject _launchLocation;
    

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        if(_burst) StartCoroutine(BulletBurst());
        if (!_burst) InvokeRepeating(nameof(BulletShot), _interval, _interval);
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = _move * _moveSpeed;
    }

    private void BulletShot()
    {
        var bullet = Instantiate(_bulletPrefab, _launchLocation.transform.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = Vector3.right * _bulletSpeed;

    }

    private IEnumerator BulletBurst()
    {
        while (true)
        {
            for (int bulletCount = 0; bulletCount < _maxBulletCount; bulletCount++)
            {
                BulletShot();
                yield return new WaitForSeconds(_burstInterval);
            }
            yield return new WaitForSeconds(_interval);
        }
    }

    void OnMove(InputValue value)
    {
        _move = value.Get<Vector2>();
    }
}
