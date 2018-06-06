using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ChangeSettings : MonoBehaviour {
    public GameObject player;
    public AudioMixer audioMixer;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void ChangeMusicVolume(float volume)
    {
        if(volume != 0)
        {
            volume = volume * 40 - 20;
        }
        else
        {
            volume = -80;
        }
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void ChangeSoundVolume(float volume)
    {

    }

    public void ChangeSensibility(float sensibility)
    {
        player.GetComponent<Rotation>().sensibility = sensibility * 2 + 1;
    }
}
