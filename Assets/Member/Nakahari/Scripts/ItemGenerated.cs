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
    [SerializeField]
    private Slider _suiSlider;

    private int _count = 0;

    private int _listCount;

    private float _currentHp;
    private float _ratioHp;

    [SerializeField]
    private BossStatus _boss;

    // Start is called before the first frame update
    void Start()
    {
        _listCount = _player.ItemPos.Count;
        _ratioHp = _boss._hp * 0.2f;
        _currentHp = _boss._hp;
    }

    // Update is called once per frame
    void Update()
    {
        Generated();
        BossBattleGenerated();
    }

    private void BossBattleGenerated()
    {
        if (_mikoSlider.value < 100) return;
        if (_boss._hp <= _currentHp - _ratioHp)
        {
            if (_currentHp == _ratioHp) return;
            _currentHp -= _ratioHp;
            float posY = Random.Range(_rangeDown.transform.position.y, _rangeUp.transform.position.y);
            float posX = Random.Range(_rangeDown.transform.position.x, _rangeUp.transform.position.x);
            Instantiate(_item, new Vector2(posX, posY), Quaternion.identity);
        }
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
