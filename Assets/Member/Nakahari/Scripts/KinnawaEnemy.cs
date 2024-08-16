using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinnawaEnemy : MonoBehaviour
{
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


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Beam());
    }

    IEnumerator Beam()
    {
        while (true)
        {
            yield return new WaitForSeconds(_ct - 1);
            var warning = Instantiate(_warningObj, _warningPos.position, Quaternion.identity);
            yield return new WaitForSeconds(_warningTime);
            Destroy(warning);
            Instantiate(_beamObj, _beamPos.position + _offset, Quaternion.identity);
        }
    }
}
