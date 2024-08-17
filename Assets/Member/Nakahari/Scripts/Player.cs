using System;
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
    [Tooltip("プレイヤーのHP")] private  int _hp;
    public int Hp => _hp;
    [SerializeField]
    [Tooltip("プレイヤーの速度")] private float _moveSpeed;
    [SerializeField]
    [Tooltip("無敵時間")] private float _invincibleTimer;

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
    private bool _pauseAction;
    [SerializeField]
    private Canvas _pauseCanvas;
    public bool _isPause;

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
        _pauseCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        _rb.velocity = _move * _moveSpeed;
        Damage();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            if(_maxBulletCount < 2)
            {
                _maxBulletCount++;
                _launchPoint.Add(_launchLocation[_maxBulletCount]);
            }
            Destroy(other.gameObject);
            SE.Instance.RandomPlaySe(RandomState.Item, RandomSEType.Item);
            if (_hp >= 5) return;
            _hp++;
        }

        if (other.gameObject.CompareTag("Bullet2"))
        {
            if (_damage) return;
            _damage = true;
            if(_maxBulletCount > 0)
            {
                _launchPoint.Remove(_launchLocation[_maxBulletCount]);
                _maxBulletCount--;
            }
            if (_hp > 0)
            {
                _hp--;
            }
            foreach (GameObject obj in _damageImage)
            {
                obj.SetActive(true);
            }
            _faceIdle.SetActive(false);
            _animator.SetTrigger("Invincible");
            if(_hp >= 2)
            {
                SE.Instance.RandomPlaySe(RandomState.Damage, RandomSEType.Damage);
            }
            else if(_hp == 1)
            {
                Debug.Log("Last");
                SE.Instance.RandomPlaySe(RandomState.Last, RandomSEType.Last);
            }
            
            
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
                _damage = false;
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
    
    void PauseScreen()
    {
        if (SceneFader.Instance._isFade) return;
        if (!_isPause)
        {
            if (_pauseAction)
            {
                _pauseCanvas.enabled = true;
                _isPause = true;
                Time.timeScale = 0;
            }
        }
        else
        {
            if (_pauseAction)
            {
                _pauseCanvas.enabled = false;
                _isPause = false;
                Time.timeScale = 1;
            }
        }
    }

    void OnMove(InputValue value)
    {
        _move = value.Get<Vector2>();
    }

    void OnPause(InputValue value)
    {
        _pauseAction = value.isPressed;
        if (!_isPause)
        {
            if (value.isPressed)
            {
                SE.Instance.PlaySe(SEType.SE1);
                _pauseCanvas.enabled = true;
                _isPause = true;
                Time.timeScale = 0;
            }
        }
        else
        {
            if (value.isPressed)
            {
                SE.Instance.PlaySe(SEType.SE2);
                _pauseCanvas.enabled = false;
                _isPause = false;
                Time.timeScale = 1;
            }
        }
    }

    void OnUp()
    {
        if(_hp <= 4)
        {
            _hp++;
        }
        if (_maxBulletCount == 2) return;
        _maxBulletCount++;
        _launchPoint.Add(_launchLocation[_maxBulletCount]);
    }

    void OnDown()
    {
        if (_hp > 0)
        {
            _hp--;
        }
        if (_hp < 0) _hp = 0;
        if (_maxBulletCount == 0) return;
        _launchPoint.RemoveAt(_maxBulletCount);
        _maxBulletCount--;
    }
}
