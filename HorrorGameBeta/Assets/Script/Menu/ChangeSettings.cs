using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ChangeSettings : MonoBehaviour {
    public GameObject player;
    public AudioMixer audioMixer;
    private Controls controls;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        controls = Controls.LoadFromFile(Application.dataPath + "/Save/controls.xml");
    }

    public void ChangeMusicVolume(float volume)
    {
        if (volume != 0)
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
        if (volume != 0)
        {
            volume = volume * 40 - 20;
        }
        else
        {
            volume = -80;
        }
        audioMixer.SetFloat("SoundVolume", volume);
        audioMixer.SetFloat("PlayerVolume", volume);
        audioMixer.SetFloat("FlashlightVolume", volume);
        audioMixer.SetFloat("MenuVolume", volume);
        audioMixer.SetFloat("KidVolume", volume);
        audioMixer.SetFloat("RedVolume", volume);
    }

    public void ChangeSensibility(float sensibility)
    {
        player.GetComponent<Rotation>().sensibility = sensibility * 2 + 1;
    }

    public void ChangeParamMusic(float value)
    {
        controls.lstSliders[0].sliderValue = value;
    }

    public void ChangeParamSound(float value)
    {
        controls.lstSliders[1].sliderValue = value;
    }

    public void ChangeParamGame(float value)
    {
        controls.lstSliders[2].sliderValue = value;
    }
}
