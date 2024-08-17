using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStatus : MonoBehaviour
{
    private float attackTime;
    private float moveTime;
    private float vecX;
    private float vecY;
    private float dis;
    private Vector2 playerPos;
    private Vector2 bossPos;
    private Vector2 originalPos;
    private bool _damageFlag;
    private bool _attackFlag;
    private bool attack2;
    [SerializeField]
    private Vector2 offset;
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    public int _hp;
    [SerializeField]
    private GameObject _muzzle;
    [SerializeField]
    private List<GameObject> _bullets;
    [SerializeField]
    private float _bulletSpeed;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject _attack2Obj;
    [SerializeField]
    private GameObject _damageFace;
    [SerializeField]
    private GameObject _idolFace;

    public Slider healthSlider;

    private void Start()
    {
        _damageFlag = false;
        _attackFlag = false;
        moveTime = 0;
        attackTime = 0;
        _damageFace.SetActive(false);
        _idolFace.SetActive(true);

        if (healthSlider != null)
        {
            healthSlider.maxValue = _hp;
            healthSlider.value = _hp;
        }
    }

    private void Update()
    {
        bossPos = this.transform.position;
        dis = Vector2.Distance(playerPos, bossPos);

        if (_damageFlag == false)
        {
            moveTime -= Time.deltaTime;
            if (moveTime <= 0.0f && attack2 == false)
            {
                vecX = Random.Range(2, 5);
                vecY = Random.Range(-3, 3);
                transform.localPosition = new Vector3(vecX, vecY, 0);
                moveTime = 2.0f;
            }
            if (_attackFlag == false)
            {
                attackTime += Time.deltaTime;
            }
            if (attackTime >= 3.0f)
            {
                _attackFlag = true;
                attackTime = 0.0f;
                int randomAttack = Random.Range(1, 10);
                Debug.Log(randomAttack);
                if (randomAttack <= 7)
                {
                    Attack1();
                }
                else if (randomAttack > 7)
                {
                    attack2 = true;
                    playerPos = _player.transform.localPosition;
                    originalPos = transform.position;
                    Debug.Log("青木");
                    StartCoroutine(Test());
                }
            }
        }
        //if (dis <= 0.5f && attack2 == true)
        //{
        //    Attack2();
        //}
    }

    private void BulletMove(GameObject bullet)
    {
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = -Vector3.right * _bulletSpeed;
    }

    private void Attack1()
    {
        Debug.Log("Attack1");
        StartCoroutine(AttackInterval());
    }

    private void Attack2()
    {
        //Debug.Log("waaaa");
        //playerPos = _player.transform.position;
        //if (dis >= 0.5f)
        //{
        //    Debug.Log("青木");
        //    gameObject.GetComponent<Rigidbody2D>().velocity = (playerPos - bossPos) * _moveSpeed;
        //    Debug.Log(playerPos - bossPos);
        //}
        //if (dis <= 0.5f)
        //{
        //    Debug.Log("悠人");
        //    gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //    Instantiate(_attack2Obj, _muzzle.transform.position, Quaternion.identity);
        //    StartCoroutine(AttackMotion());
        //    attack2 = false;
        //}
        Debug.Log("悠人");
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Instantiate(_attack2Obj, _muzzle.transform.position, Quaternion.identity);
        StartCoroutine(AttackMotion());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            ScoreManager.Instance.AddScore("Boss", "Bullet");
            _damageFlag = true;
            _idolFace.SetActive(false);
            _damageFace.SetActive(true);
            _hp--;
            StartCoroutine(DamageCoolTime());
        }
    }

    private IEnumerator Test()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = (playerPos - bossPos + offset) * _moveSpeed;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Attack2();
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<Rigidbody2D>().velocity = (originalPos - bossPos) * _moveSpeed;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(0.3f);
        attack2 = false;
    }

    private IEnumerator AttackInterval()
    {
        for (int i = 0; i < 5; i++)
        {
            int randomBullet = Random.Range(0, 24);
            var _instantiateBullet = Instantiate(_bullets[randomBullet], _muzzle.transform.position, Quaternion.identity);
            BulletMove(_instantiateBullet);
            yield return new WaitForSeconds(0.2f);
            if (i == 4)
            {
                _attackFlag = false;
            }
        }
    }

    private IEnumerator AttackMotion()
    {
        yield return new WaitForSeconds(0.2f);
        _attackFlag = false;
    }

    private IEnumerator DamageCoolTime()
    {
        yield return new WaitForSeconds(2);
        _damageFlag = false;
        _idolFace.SetActive(true);
        _damageFace.SetActive(false);
    }
}
