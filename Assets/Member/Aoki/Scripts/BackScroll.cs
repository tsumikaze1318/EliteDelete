using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BackScroll : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2.0f;  // スクロールの速度
    private bool isScrolling = true;

    void Update()
    {
        if(isScrolling)
        {
            transform.position += new Vector3(scrollSpeed * Time.deltaTime, 0, 0);
            if(transform.position.x >= 100)
            {
                isScrolling = false;
            }
        }
    }
}


    //private float length, startpos;
    //[SerializeField] private GameObject cam;
    //[SerializeField] private float parallaxEffect;

    //void Start()
    //{
    //    startpos = transform.position.x;
    //    //length = GetComponent<SpriteRenderer>().bounds.size.x;
    //}
    //private void FixedUpdate()
    //{
    //    float temp = (cam.transform.position.x * (1 - parallaxEffect));
    //    float dist = (cam.transform.position.x * parallaxEffect);
    //    transform.position = new Vector3(startpos + dist,transform.position.y,transform.position.z);
    //    if (temp > startpos + length) startpos += length;
    //    else if (temp < startpos - length) startpos -= length;
    //}
