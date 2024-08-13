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
    private double _time;
    private bool _damageFlag;
    private int _hp;
    private float _attackTime;
    private float _nextAttack;

    void Start()
    {
        _hp = 50;
        _damageFlag = false;
        _attackTime = 3.0f;

        //Debug—p
        //StartCoroutine(DamageCoolTime());
    }

    void Update()
    {
        _attackTime -= Time.deltaTime;
        if (_attackTime <= 0.0f)
        {
            Attack();
        }
        if (_damageFlag == true)
        {
            _time += Time.deltaTime;
            var repeatValue = Mathf.Repeat((float)_time, _cycle);
            _enemyRen.enabled = repeatValue >= _cycle * 0.5f;
        }
        if (_hp == 0)
        {
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if (_damageFlag == false)
            {
                _hp--;
                _damageFlag = true;
                StartCoroutine(DamageCoolTime());
            }
        }
    }

    private IEnumerator DamageCoolTime()
    {
        yield return new WaitForSeconds(1);
        _damageFlag = false;
        _enemyRen.enabled = true;
    }
}
