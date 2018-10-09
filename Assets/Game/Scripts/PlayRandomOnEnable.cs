using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomOnEnable : MonoBehaviour
{
    public OnEnableClips[] clips;
    AudioSource source;

    private void OnEnable()
    {
        if (source == null)
            source = GetComponent<AudioSource>();
        foreach(OnEnableClips clip in clips)
        {
            source.PlayOneShot(clip.clips[Random.Range(0, clip.clips.Length)]);
        }
    }
}

[System.Serializable]
public class OnEnableClips
{
    public AudioClip[] clips;
}
