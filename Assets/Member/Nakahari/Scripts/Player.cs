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
    [Tooltip("バースト回数")] private float _burstNum;

    private int _maxBulletCount = 0;


    [Header("--------------------------------")]
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private List<GameObject> _launchLocation = new List<GameObject>();
    private List<GameObject> _launchPoint = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        _launchPoint.Add(_launchLocation[0]);
        _rb = GetComponent<Rigidbody2D>();
        if(_burst) StartCoroutine(BulletBurst());
        if (!_burst) InvokeRepeating(nameof(BulletInstantiate), _interval, _interval);
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = _move * _moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            _launchPoint.Add(_launchLocation[_maxBulletCount]);
        }
    }

    private void BulletShot(GameObject bulletObj)
    {
        Rigidbody2D bulletRb = bulletObj.GetComponent<Rigidbody2D>();
        bulletRb.velocity = Vector3.right * _bulletSpeed;
    }

    private void BulletInstantiate()
    {
        foreach(GameObject bullet in _launchPoint)
        {
            var instantiateObj = Instantiate(_bulletPrefab, bullet.transform.position, Quaternion.identity);
            BulletShot(instantiateObj);
        }
        
    }

    private IEnumerator BulletBurst()
    {
        while (true)
        {
            for (int bulletCount = 0; bulletCount < _burstNum; bulletCount++)
            {
                BulletInstantiate();
                yield return new WaitForSeconds(_burstInterval);
            }
            yield return new WaitForSeconds(_interval);
        }
    }

    void OnMove(InputValue value)
    {
        _move = value.Get<Vector2>();
    }

    void OnUp()
    {
        if (_maxBulletCount == 2) return;
        _maxBulletCount++;
        _launchPoint.Add(_launchLocation[_maxBulletCount]);
    }

    void OnDown()
    {
        if (_maxBulletCount == 0) return;
        _launchPoint.RemoveAt(_maxBulletCount);
        _maxBulletCount--;
    }
}
