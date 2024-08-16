using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum RandomSEType
{
    Start,
    InGame,
    Item,
    Damage,
    Last,
    Boss,
    Claer,
    GameOver
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
    GameOver
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
public class TestSe : MonoBehaviour
{
    [SerializeField]
    List<AudioClip> _randomClip = new List<AudioClip>();
    [SerializeField]
    private List<RandomSEData> _randomData = new List<RandomSEData>();
    [SerializeField]
    private AudioSource seSource = null;

    void RandomPlaySe(RandomState state, SEType type)
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
            break;
        }
    }
}
