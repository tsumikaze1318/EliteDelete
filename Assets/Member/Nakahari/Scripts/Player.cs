using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 _move = Vector2.zero;
    private Rigidbody2D _rb;

    [Header("プレイヤーのステータス")]
    [SerializeField]
    private  int _hp;
    public int Hp => _hp;
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _invincibleTimer;

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

    [Header("アイテム関連")]

    [SerializeField]
    [Tooltip("アイテム出現させるタイミング")]
    private List<float> _itemPos = new List<float>();
    public List<float> ItemPos => _itemPos;


    [Header("--------------------------------")]
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private List<GameObject> _launchLocation = new List<GameObject>();
    private List<GameObject> _launchPoint = new List<GameObject>();
    [SerializeField]
    private GameObject _faceIdle;
    [SerializeField]
    private List<GameObject> _damageImage = new List<GameObject>();
    private bool _damage = false;
    private float _timer = 0;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _launchPoint.Add(_launchLocation[0]);
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        if (_burst) StartCoroutine(BulletBurst());
        if (!_burst) InvokeRepeating(nameof(BulletInstantiate), _interval, _interval);
        foreach(GameObject obj in _damageImage)
        {
            obj.SetActive(false);
        }
        _faceIdle.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = _move * _moveSpeed;
        Damage();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            _hp++;
            _maxBulletCount++;
            _launchPoint.Add(_launchLocation[_maxBulletCount]);
            Destroy(other.gameObject);
            if(_hp > 5) _hp = 5;
        }

        if (other.gameObject.CompareTag("Bullet"))
        {
            if (_damage) return;
            _damage = true;
            _hp--;
            foreach (GameObject obj in _damageImage)
            {
                obj.SetActive(true);
            }
            _faceIdle.SetActive(false);
            _animator.SetTrigger("Invincible");
            if (_hp < 0) _hp = 0;
        }
    }

    private void Damage()
    {
        if (_damage)
        {
            _timer += Time.deltaTime;
            if(_timer >= _invincibleTimer)
            {
                _faceIdle.SetActive(true);
                foreach (GameObject obj in _damageImage)
                {
                    obj.SetActive(false);
                }
                _timer = 0;
            }
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
        _hp++;
        if (_hp > 5) _hp = 5;
        if (_maxBulletCount == 2) return;
        _maxBulletCount++;
        _launchPoint.Add(_launchLocation[_maxBulletCount]);
    }

    void OnDown()
    {
        _hp--;
        if (_hp < 0) _hp = 0;
        if (_maxBulletCount == 0) return;
        _launchPoint.RemoveAt(_maxBulletCount);
        _maxBulletCount--;
    }
}
