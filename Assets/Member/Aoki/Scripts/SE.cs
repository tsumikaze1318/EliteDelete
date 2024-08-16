using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BGMType
{
    BGM1,
    BGM2,
    BGM3,
    BGM4,
    BGM5,
    Null
}
//シリアライズ化
[System.Serializable]
struct BGMData
{
    public BGMType Type;
    public AudioClip Clip;
    [Range(0, 1)]
    public float Volume;
    public bool Loop;
}
public enum SEType
{
    SE1,
    SE2,
    SE3,
    SE4,
    SE5,
    SE6
}

//シリアライズ化
[System.Serializable]
struct SEData
{
    public SEType Type;
    public AudioClip Clip;
    [Range(0, 1)]
    public float Volume;
    public bool Loop;
}

public enum RandomSEType
{
    Start,
    InGame,
    Item,
    Damage,
    Last,
    Boss,
    Claer,
    GameOver,
    Sui,
    SuiHP
}

public enum RandomState
{
    Start,
    InGame,
    Item,
    Damage,
    Last,
    Boss,
    Claer,
    GameOver,
    Sui,
    SuiHP
}

[System.Serializable]
struct RandomSEData
{
    public RandomSEType Type;
    public AudioClip Clip;
    [Range(0, 1)]
    public float Volume;
    public bool Loop;
}

public class SE : MonoBehaviour
{
    private static SE instance;
    public static SE Instance { get => instance; }
    //ゲーム内で再生するBGMのリスト
    [SerializeField]
    private List<BGMData> bgmDataList = new List<BGMData>();

    [SerializeField]
    private List<SEData> seDataList = new List<SEData>();

    [SerializeField]
    private AudioSource bgmSource = null;

    [SerializeField]
    List<AudioClip> _randomClip = new List<AudioClip>();
    [SerializeField]
    private List<RandomSEData> _randomData = new List<RandomSEData>();
    [SerializeField]
    private AudioSource seSource = null;
    


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        { instance = this; }
        else return;
        PlayBgm(BGMType.BGM1);
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        //テスト
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SE.Instance.PlaySe(SEType.SE2);
        if (Input.GetKey(KeyCode.Alpha2))
            SE.Instance.PlayLoopSe(SEType.SE1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SE.Instance.StopBgm();
    }
    //BGM再生
    public void PlayBgm(BGMType type)
    {
        if (type == BGMType.Null) return;
        var bgm = bgmDataList[(int)type];
        bgmSource.clip = bgm.Clip;
        bgmSource.volume = bgm.Volume;
        bgmSource.loop = bgm.Loop;
        bgmSource.Play();
    }
    public void StopBgm()
    {
        bgmSource.Stop();
    }

    public void PlaySe(SEType type)
    {
        var se = seDataList[(int)type];
        seSource.clip = se.Clip;
        seSource.volume = se.Volume;
        seSource.PlayOneShot(se.Clip);
    }
    //サウンドループ再生
    public void PlayLoopSe(SEType type)
    {
        var se = seDataList[(int)type];
        seSource.clip = se.Clip;
        seSource.loop = se.Loop;
        seSource.volume = se.Volume;
        seSource.Play();
    }

    public void StopLoopBgm()
    {
        seSource.Stop();
    }

    public AudioSource PassAudioSource()
    {
        return seSource;
    }
    public void RandomPlaySe(RandomState state, RandomSEType type)
    {
        switch (state)
        {
            case RandomState.Start:
                var random = Random.Range(0, 1);
                var clip = _randomClip[random];
                var se = _randomData[(int)type];
                seSource.clip = clip;
                seSource.volume = se.Volume;
                seSource.PlayOneShot(clip);
                Debug.Log("いくぞ！！");
                break;
            case RandomState.InGame:
                var random1 = Random.Range(2, 5);
                var clip1 = _randomClip[random1];
                var se1 = _randomData[(int)type];
                seSource.clip = clip1;
                seSource.volume = se1.Volume;
                seSource.PlayOneShot(clip1);
                Debug.Log("ダイジョブダッテ");
                break;
            case RandomState.Item:
                var random2 = Random.Range(6, 7);
                var clip2 = _randomClip[random2];
                var se2 = _randomData[(int)type];
                seSource.clip = clip2;
                seSource.volume = se2.Volume;
                seSource.PlayOneShot(clip2);
                break;
            case RandomState.Damage:
                var random3 = Random.Range(8, 11);
                var clip3 = _randomClip[random3];
                var se3 =_randomData[(int)type];
                seSource.clip = clip3;
                seSource.volume = se3.Volume;
                seSource.PlayOneShot(clip3);
                break;
            case RandomState.Last:
                var random4 = Random.Range(12, 13);
                var clip4 = _randomClip[random4];
                var se4 = _randomData[(int)type];
                seSource.clip = clip4;
                seSource.volume = se4.Volume;
                seSource.PlayOneShot(clip4);
                break;
            case RandomState.Boss:
                var random5 = Random.Range(14, 16);
                var clip5 = _randomClip[random5];
                var se5 = _randomData[(int)type];
                seSource.clip = clip5;
                seSource.volume = se5.Volume;
                seSource.PlayOneShot(clip5);
                Debug.Log("PON");
                break;
            case RandomState.Claer:
                var random6 = Random.Range(17, 18);
                var clip6 = _randomClip[random6];
                var se6 = _randomData[(int)type];
                seSource.clip = clip6;
                seSource.volume = se6.Volume;
                seSource.PlayOneShot(clip6);
                break;
            case RandomState.GameOver:
                var random7 = Random.Range(19, 20);
                var clip7 = _randomClip[random7];
                var se7 = _randomData[(int)type];
                seSource.clip = clip7;
                seSource.volume = se7.Volume;
                seSource.PlayOneShot(clip7);
                break;
            case RandomState.Sui:
                var random8 = Random.Range(21, 22);
                var clip8 = _randomClip[random8];
                var se8 = _randomData[(int)type];
                seSource.clip = clip8;
                seSource.volume = se8.Volume;
                seSource.PlayOneShot(clip8);
                break;
            case RandomState.SuiHP:
                var random9 = Random.Range(23, 29);
                var clip9 = _randomClip[random9];
                var se9 = _randomData[(int)type];
                seSource.clip = clip9;
                seSource.volume = se9.Volume;
                seSource.PlayOneShot(clip9);
                break;
        }
    }
}