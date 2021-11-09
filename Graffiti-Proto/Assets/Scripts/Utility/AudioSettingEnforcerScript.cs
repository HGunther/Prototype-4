using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioType { MUSIC, SOUND }

public class AudioSettingEnforcerScript : MonoBehaviour
{
    public AudioType audioType;
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        UpdateAudioSetting();
    }

    public void UpdateAudioSetting()
    {
        if(audioType == AudioType.MUSIC)
        {
            if (PlayerPrefs.GetInt("isMusicOn") == 1)
                audioSource.enabled = true;
            else
                audioSource.enabled = false;
        }
        if(audioType == AudioType.SOUND)
        {
            if (PlayerPrefs.GetInt("isSoundOn") == 1)
                audioSource.enabled = true;
            else
                audioSource.enabled = false;
        }
    }
}
