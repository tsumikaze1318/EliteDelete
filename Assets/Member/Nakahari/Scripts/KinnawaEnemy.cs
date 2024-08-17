using System.Collections;
using UnityEngine;

public class KinnawaEnemy : MonoBehaviour
{
    [SerializeField]
    private Renderer _enemyRen;
    [SerializeField]
    private float _cycle = 0.2f;
    [SerializeField]
    private float _ct;
    [SerializeField]
    private float _warningTime;
    [SerializeField]
    private GameObject _warningObj;
    [SerializeField]
    private GameObject _beamObj;
    [SerializeField]
    private Transform _beamPos;
    [SerializeField]
    private Transform _warningPos;
    [SerializeField]
    private Vector3 _offset;
    private Transform _target;
    private float _moveSpeed = 1;
    private int _hp;
    private EnemySpawn _enemySpawn;
    private double _time;
    private Rigidbody2D _rb;
    private bool _damageFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        _hp = 50;
        _enemySpawn = GetComponentInParent<EnemySpawn>();
        _rb = GetComponent<Rigidbody2D>();
        _target = _enemySpawn.target[Random.Range(0,2)];
        _rb.velocity = new Vector2(_target.transform.position.x - this.transform.position.x, 0) * _moveSpeed;
        StartCoroutine(Beam());
    }

    private void Update()
    {
        if (_damageFlag == true)
        {
            TakeDamage();
        }
        if (_hp <= 0)
        {
            ScoreManager.Instance.AddScore(gameObject.tag);
            _enemySpawn._enemyList.Remove(gameObject);
            Destroy(this.gameObject);
        }
        if(this.transform.localPosition.x <= _target.transform.localPosition.x)
        {
            Debug.Log("yuuuuutooo");
            _rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            _hp -= 10;
            _damageFlag = true;
            StartCoroutine(DamageCoolTime());
            Destroy(other.gameObject);
        }
    }
    private void TakeDamage()
    {
        _time += Time.deltaTime;
        var repeatValue = Mathf.Repeat((float)_time, _cycle);
        _enemyRen.enabled = repeatValue >= _cycle * 0.5f;
    }

    private IEnumerator DamageCoolTime()
    {
        yield return new WaitForSeconds(1);
        _damageFlag = false;
        _enemyRen.enabled = true;
        _time = 0;
    }

    IEnumerator Beam()
    {
        while (true)
        {
            yield return new WaitForSeconds(_ct - 1);
            var warning = Instantiate(_warningObj, _warningPos.position, Quaternion.identity);
            warning.transform.parent = this.transform;
            yield return new WaitForSeconds(_warningTime);
            Destroy(warning);
            var beam = Instantiate(_beamObj, _beamPos.position + _offset, Quaternion.identity);
            beam.transform.parent = this.transform;
        }
    }
}
