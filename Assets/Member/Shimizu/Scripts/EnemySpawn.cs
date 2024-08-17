using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _enemies;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private Transform _rangeUp;
    [SerializeField]
    private Transform _rangeDown;
    [SerializeField]
    public Transform target;

    public List<GameObject> _enemyList = new List<GameObject>();

    private void Start()
    {
        
    }

    private void Update()
    {
        if (_enemyList.Count < 4 && slider.value >= 5 && slider.value < 30)
        {
            float posY = Random.Range(_rangeDown.transform.position.y, _rangeUp.transform.position.y);
            float posX = Random.Range(_rangeDown.transform.position.x, _rangeUp.transform.position.x);
            var aoki = Instantiate(_enemies[0], new Vector2(posX, posY), Quaternion.identity);
            aoki.transform.parent = this.transform;
            _enemyList.Add(aoki);
        }
        if (_enemyList.Count < 4 && slider.value >= 30 && slider.value < 80)
        {
            float posY = Random.Range(_rangeDown.transform.position.y, _rangeUp.transform.position.y);
            float posX = Random.Range(_rangeDown.transform.position.x, _rangeUp.transform.position.x);
            int randomEnemy = Random.Range(1, 11);
            Debug.Log(randomEnemy);
            if (randomEnemy <= 8)
            {
                var yuto = Instantiate(_enemies[0], new Vector2(posX, posY), Quaternion.identity);
                yuto.transform.parent = this.transform;
                _enemyList.Add(yuto);
            }
            if (randomEnemy > 8)
            {
                var nakahari = Instantiate(_enemies[1], new Vector2(posX, posY), Quaternion.identity);
                nakahari.transform.parent = this.transform;
                _enemyList.Add(nakahari);
            }
        }
    }
}
