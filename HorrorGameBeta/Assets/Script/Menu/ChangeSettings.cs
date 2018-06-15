using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Script that will save the User's preferences for the volume and the sensibility
/// </summary>
public class ChangeSettings : MonoBehaviour {

    //Objects
    public GameObject player;
    public AudioMixer audioMixer;
    public Controls controls;

    /// <summary>
    /// Method which change the music volume
    /// </summary>
    /// <param name="volume">Value of the slider</param>
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

    /// <summary>
    /// Method which change the sound volume
    /// </summary>
    /// <param name="volume">Value of the slider</param>
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

    /// <summary>
    /// Method which change the camera sensibility
    /// </summary>
    /// <param name="volume">Value of the slider</param>
    public void ChangeSensibility(float sensibility)
    {
        player.GetComponent<Rotation>().sensibility = sensibility * 2 + 1;
    }

    /// <summary>
    /// Method which save the value of the music volume in the Controls
    /// </summary>
    /// <param name="volume">Value of the slider</param>
    public void ChangeParamMusic(float value)
    {
        controls.lstSliders[0].sliderValue = value;
        controls.Save(Application.dataPath + "/Save/controls.xml");
    }

    /// <summary>
    /// Method which save the value of the sound volume in the Controls
    /// </summary>
    /// <param name="volume">Value of the slider</param>
    public void ChangeParamSound(float value)
    {
        controls.lstSliders[1].sliderValue = value;
        controls.Save(Application.dataPath + "/Save/controls.xml");
    }

    /// <summary>
    /// Method which save the value of the camera sensibility in the Controls
    /// </summary>
    /// <param name="volume">Value of the slider</param>
    public void ChangeParamGame(float value)
    {
        controls.lstSliders[2].sliderValue = value;
        controls.Save(Application.dataPath + "/Save/controls.xml");
    }
}
