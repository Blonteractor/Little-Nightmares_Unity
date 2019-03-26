using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct InvokeProperties
{
    [Header("Low Pitch Laugh")]
    public Vector2 lowPitchStart;
    public Vector2 lowPitchDelay;

    [Header("High Pitch Laugh")]
    public Vector2 highPitchDelay;
    public Vector2 highPitchStart;
}

public class LaughsManager : MonoBehaviour
{
    public InvokeProperties invokeProperties;

    [Space]
    public AudioSource lowPitchLaugh;
    public AudioSource highPitchLaugh;

    private void Start()
    {
        highPitchLaugh.loop = false;
        lowPitchLaugh.loop = false;
        InvokeRepeating("PlayLowPitch", Random.Range(invokeProperties.lowPitchStart.x, invokeProperties.lowPitchStart.y ), Random.Range(invokeProperties.lowPitchDelay.x, invokeProperties.lowPitchDelay.y));
        InvokeRepeating("PlayHighPitch", Random.Range(invokeProperties.highPitchStart.x, invokeProperties.highPitchStart.y), Random.Range(invokeProperties.highPitchDelay.x, invokeProperties.highPitchDelay.y));
    }
    void PlayHighPitch()
    {
        highPitchLaugh.Play();
    }

    void PlayLowPitch()
    {
        lowPitchLaugh.Play();
    }
}
