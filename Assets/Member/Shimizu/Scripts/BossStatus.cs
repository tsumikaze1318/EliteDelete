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
    }
}
