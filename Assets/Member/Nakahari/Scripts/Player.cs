using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 _move = Vector2.zero;
    [Header("�v���C���[�̃X�e�[�^�X")]
    [SerializeField]
    public int _hp;
    [SerializeField]
    private float _moveSpeed;

    private Rigidbody2D _rb;

    [Header("�e�̃X�e�[�^�X")]
    [SerializeField]
    [Tooltip("�e�̑��x")] private float _bulletSpeed;
    [SerializeField]
    [Tooltip("���ˊԊu")] private float _interval;
    [SerializeField]
    [Tooltip("�o�[�X�g�ɂ��邩�ǂ���")] private bool _burst;
    [SerializeField]
    [Tooltip("�o�[�X�g�Ԋu")] private float _burstInterval;
    [SerializeField]
    [Tooltip("�o�[�X�g��")] private int _maxBulletCount;


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
