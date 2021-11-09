using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerScript : MonoBehaviour
{
    public static AudioPlayerScript instance;
    public AudioSource soundSource;
    public AudioClip backHome;
    public AudioClip audioSettingChanged;
    public AudioClip levelCategorySelect;
    public AudioClip levelComplete;
    public AudioClip oneCoinEarned;
    public AudioClip streakCoinsEarned;
    public AudioClip coinTrail;
    public AudioClip victorySound;

    Dictionary<string, AudioClip> soundClips;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        soundClips = new Dictionary<string, AudioClip>
        {
            { "ui_button", backHome },
            { "audio_setting_changed", audioSettingChanged },
            { "level_category_select", levelCategorySelect },
            { "level_complete", levelComplete },
            { "1_coin_earned", oneCoinEarned },
            { "streak_coins_earned", streakCoinsEarned },
            { "coin_trail", coinTrail },
            { "victory_sound", victorySound },
        };

        DontDestroyOnLoad(gameObject);
    }

    public void PlaySound(string soundName)
    {
        soundSource.clip = soundClips[soundName];
        soundSource.Play();
    }
}
