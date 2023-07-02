using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManagerScript : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] AudioSource music;

    bool isMuted = false;
    public void MuteMusic()
    {
        isMuted = !isMuted;
        if (isMuted)
        {
            text.text = "Unmute music";
            music.mute = true;
        }
        else
        {
            text.text = "Mute music";
            music.mute = false;
        }

    }
}
