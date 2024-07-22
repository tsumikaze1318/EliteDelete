using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject _enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var _target = _player.transform.position - _enemy.transform.position;
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(_target * 10f);
    }
}
