using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    private VideoPlayer _video;
    [SerializeField]
    private Canvas _canvas;
    [SerializeField]
    private Slider _slider;
    private bool _isPlaying;
    [SerializeField]
    private GameObject _videoObj;
    private Image _image;
    private bool _inOut;

    private void Awake()
    {
        _video = GetComponentInChildren<VideoPlayer>();
        _image = _canvas.GetComponentInChildren<Image>();
        _isPlaying = false;
        _inOut = false;
        _videoObj.SetActive(false);
        _canvas.enabled = false;
        Debug.Log("aaa");
    }

    private void Start()
    {
        _video.loopPointReached += OffCanvas;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPlaying)
        {
            if(_slider.value >= 99)
            {
                if (!_inOut)
                {
                    _inOut = true;
                    StartCoroutine(In());
                }
            }
            if (_slider.value >= 100)
            {
                SE.Instance.PlaySe(SEType.SE5);
                _isPlaying = true;
                _videoObj.SetActive(true);
                _video.Play();
                
            }
        }
        
    }

    IEnumerator In()
    {
        _canvas.enabled = true;
        float t = 0f;
        while (t < 0.5f)
        {
            t += Time.deltaTime;
            float alpha = t / 1f;
            SetAlpha(alpha);
            yield return null;
        }
        SetAlpha(0.588f);
    }

    IEnumerator Out()
    {
        float t = 0.5f;
        while (t > 0f)
        {
            t -= Time.deltaTime;
            float alpha = t / 1f;
            SetAlpha(alpha);
            yield return null;
        }
        _canvas.enabled = false;
        SetAlpha(0f);
    }

    private void SetAlpha(float alpha)
    {
        Color color = _image.color;
        color.a = alpha;
        _image.color = color;
    }

    void OffCanvas(VideoPlayer vp)
    {
        _videoObj.SetActive(false);
        StartCoroutine(Out());
    }
}
