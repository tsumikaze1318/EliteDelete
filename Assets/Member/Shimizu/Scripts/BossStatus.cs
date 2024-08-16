using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatus : MonoBehaviour
{
    private float attackTime;
    private float moveTime;
    private float vecX;
    private float vecY;
    [SerializeField]
    private int _hp;
    [SerializeField]
    private GameObject _muzzle;
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private float _bulletSpeed;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject _attack2Obj;

    private void Start()
    {
        moveTime = 0;
        attackTime = 0;
    }

    private void Update()
    {
        moveTime -= Time.deltaTime;
        if (moveTime <= 0.0f)
        {
            vecX = Random.Range(0, 5);
            vecY = Random.Range(-5, 5);
            transform.position = new Vector3(vecX, vecY, 0);
            moveTime = 2.0f;
        }
        attackTime += Time.deltaTime;
        if (attackTime <= 3.0f)
        {
            var randomAttack = Random.Range(1, 10);
            if (randomAttack <=7)
            {
                Attack1();
            }
            else
            {
                Attack2();
            }
        }
    }

    private void BulletMove(GameObject bullet)
    {
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = -Vector3.right * _bulletSpeed;
        attackTime = 0.0f;
    }

    private void Attack1()
    {
        var _instantiateBullet = Instantiate(_bullet, _muzzle.transform.position, Quaternion.identity);
        BulletMove(_instantiateBullet);
    }

    private void Attack2()
    {
        Vector2 _playerPos = _player.transform.position;
        Vector2 _bossPos = transform.position;

        while (Mathf.Abs(_playerPos.x - _bossPos.x) == 0.5f)
        {
            _bossPos.x += (_playerPos.x - _bossPos.x) * 0.01f;
            _bossPos.y += (_playerPos.y - _bossPos.y) * 0.01f;
            transform.position = _bossPos;
        }

        if (Mathf.Abs(_playerPos.x - _bossPos.x) == 0.5f)
        {
            StartCoroutine(AttackMotion());
        }
    }

    private IEnumerator AttackMotion()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(_attack2Obj, _muzzle.transform.position, Quaternion.identity);
        attackTime = 0;
    }
}
