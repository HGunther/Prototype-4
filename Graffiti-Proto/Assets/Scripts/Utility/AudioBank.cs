using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBank : MonoBehaviour
{
    public static AudioBank instance;

    public AudioClip kick, snare, openhat, perc;
    public Dictionary<string, AudioClip> audioClips;

    void Awake()
    {
        instance = this;

        audioClips = new Dictionary<string, AudioClip>()
        {
            { "Kick", kick },
            { "Snare", snare },
            { "Openhat", openhat },
            { "Perc", perc },
        };
    }
}
