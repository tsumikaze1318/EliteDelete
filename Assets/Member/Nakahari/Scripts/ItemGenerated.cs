using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerated : MonoBehaviour
{

    [SerializeField]
    private Player _player;
    [SerializeField]
    private GameObject _item;
    [SerializeField]
    private Transform _rangeUp;
    [SerializeField]
    private Transform _rangeDown;

    private int _count = 0;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Generated();
    }

    private void Generated()
    {
        if(_player.transform.position.x >= _player.ItemPos[_count])
        {
            float posY = Random.Range(_rangeDown.transform.position.y, _rangeUp.transform.position.y);
            float posX = Random.Range(_rangeDown.transform.position.x, _rangeUp.transform.position.x);
            Instantiate(_item, new Vector2(posX, posY), Quaternion.identity);
            _count++;
        }
    }
}
