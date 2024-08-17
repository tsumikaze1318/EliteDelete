using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    private Slider _mikoSlider;

    private int _count = 0;

    private int _listCount;

    // Start is called before the first frame update
    void Start()
    {
        _listCount = _player.ItemPos.Count;
    }

    // Update is called once per frame
    void Update()
    {
        Generated();
    }

    private void Generated()
    {
        if (_count >= _listCount) return;
        if (_mikoSlider.value >= _player.ItemPos[_count])
        {
            float posY = Random.Range(_rangeDown.transform.position.y, _rangeUp.transform.position.y);
            float posX = Random.Range(_rangeDown.transform.position.x, _rangeUp.transform.position.x);
            Instantiate(_item, new Vector2(posX, posY), Quaternion.identity);
            _count++;
        }
    }
}
