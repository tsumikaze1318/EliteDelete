using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpManager : MonoBehaviour
{
    private Player _pl;
    [SerializeField]
    private Image[] _hpImages;
    [SerializeField]
    private Sprite _hpSprite;
    [SerializeField]
    private Sprite _hpDamageSprite;
    private int _maxHp;
    private int _currentHp;

    
    // Start is called before the first frame update
    void Start()
    {
        _pl = GetComponentInParent<Player>();
        _hpImages = GetComponentsInChildren<Image>();
        _maxHp = _pl.Hp;
        _currentHp = _pl.Hp;
    }

    // Update is called once per frame
    void Update()
    {
        if(_currentHp != _pl.Hp)
        {
            _currentHp = _pl.Hp;
            ChangeUi(_currentHp);
        }
    }
    void ChangeUi(int playerHp)
    {
        for(int i = 0; i < _maxHp; i++)
        {
            if (i < playerHp)
            {
                _hpImages[i].sprite = _hpSprite;
            }
            else
            {
                _hpImages[i].sprite = _hpDamageSprite;
            }
        }
    }
}
