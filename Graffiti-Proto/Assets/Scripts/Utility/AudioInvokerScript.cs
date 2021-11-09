using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInvokerScript : MonoBehaviour
{
    public void PlaySound(string soundClipName)
    {
        if(AudioPlayerScript.instance != null)
            AudioPlayerScript.instance.PlaySound(soundClipName);
        else
        {
            Debug.LogWarning("Audio Player instance not present");
        }
    }
}
