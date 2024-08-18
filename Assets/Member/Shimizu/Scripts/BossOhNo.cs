using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOhNo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OhNoDestroy());
    }

    private IEnumerator OhNoDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
