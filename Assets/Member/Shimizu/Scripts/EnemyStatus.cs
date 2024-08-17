using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField]
    private Renderer _enemyRen;
    [SerializeField]
    private float _cycle = 0.2f;
    [SerializeField]
    private GameObject _enemyBullet;
    [SerializeField]
    private GameObject _enemyMuzzle;
    [SerializeField]
    private float _bulletSpeed;
    [SerializeField]
    private GameObject _player;
    private Transform _target;
    private double _time;
    private bool _damageFlag;
    private int _hp;
    private float _attackTime;
    private float _nextAttack;
    private float _moveSpeed = 1;
    private EnemySpawn _enemySpawn;

    public static int _enemyDieCount;

    void Start()
    {
        _hp = 50;
        _damageFlag = false;
        _attackTime = 3.0f;
        _enemySpawn = GetComponentInParent<EnemySpawn>();
        _target = _enemySpawn.target;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2((_target.transform.position.x - this.transform.position.x), 0) * _moveSpeed;

        //Debug—p
        //StartCoroutine(DamageCoolTime());
    }

    void Update()
    {
        if (gameObject.transform.localPosition.x <= _target.transform.localPosition.x)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        _attackTime -= Time.deltaTime;
        if (_attackTime <= 0.0f)
        {
            Attack();
        }
        if (_damageFlag == true)
        {
            TakeDamage();
        }
        if (_hp == 0)
        {
            ScoreManager.Instance.AddScore(gameObject.tag);
            _enemySpawn._enemyList.Remove(gameObject);
            Destroy(this.gameObject);
        }
    }
    private void BulletMove(GameObject bullet)
    {
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = -Vector3.right * _bulletSpeed;
    }

    private void Attack()
    {
        var _instantiateEnemyBullet = Instantiate(_enemyBullet,_enemyMuzzle.transform.position,Quaternion.identity);
        BulletMove(_instantiateEnemyBullet);
        _nextAttack = Random.Range(3.0f, 5.0f);
        _attackTime = _nextAttack;
    }

    private void OnBecameVisible()
    {
        this.gameObject.SetActive(true);
    }

    private void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }

    private void TakeDamage()
    {
        _time += Time.deltaTime;
        var repeatValue = Mathf.Repeat((float)_time, _cycle);
        _enemyRen.enabled = repeatValue >= _cycle * 0.5f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            _hp -= 10;
            StartCoroutine(DamageCoolTime());
        }
    }

    private IEnumerator DamageCoolTime()
    {
        yield return new WaitForSeconds(1);
        _damageFlag = false;
        _enemyRen.enabled = true;
        _time = 0;
    }
}
