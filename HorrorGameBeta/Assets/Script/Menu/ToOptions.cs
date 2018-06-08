using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ToOptions : MonoBehaviour {
    public GameObject menu;
    public GameObject panelMenu;
    public GameObject panelOptions;
    public GameObject kid;
    public GameObject red;
    public GameObject player;
    public GameObject musicPlayer;
    public Camera mainCam;
    public Camera menuCam;
    public AudioMixer music;
    public AudioClip menuMusic;
    public Slider musicVolume;

    public bool redStateActif;
    public bool kidStateActif;
    public bool inGame = false;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        kid = GameObject.FindWithTag("Kid");
        red = GameObject.FindWithTag("RedEyes");
        musicPlayer = GameObject.FindWithTag("Music");
    }

    public void ToMenu()
    {
        if (inGame)
        {
            kid.transform.SetPositionAndRotation(new Vector3(2.34f, 3.62f, -1.27f), Quaternion.Euler(0, 160, 0));
            player.transform.SetPositionAndRotation(new Vector3(18.72f, 6.23f, -32.03f), Quaternion.Euler(0, 0, 0));
            player.GetComponent<Rigidbody>().useGravity = false;
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            mainCam.enabled = false;
            menuCam.enabled = true;
            inGame = false;
            kidStateActif = false;
            redStateActif = false;
            music.SetFloat("MusicVolume", musicVolume.value * 40 - 20);
            musicPlayer.GetComponent<AudioSource>().clip = menuMusic;
            musicPlayer.GetComponent<AudioSource>().Play();
        }
        panelOptions.SetActive(false);
        panelMenu.SetActive(true);
    }

    public void Validate()
    {
        if(kid.transform.position == new Vector3(2.34f, 3.62f, -1.27f))
        {
            ToMenu();
        }
        else
        {
            music.SetFloat("MusicVolume", musicVolume.value * 40 - 20);
            menu.SetActive(false);
            if (redStateActif)
            {
                red.GetComponent<Pathfinding>().enabled = true;
                red.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
            }
            if (kidStateActif)
            {
                kid.GetComponent<CheckSee>().enabled = true;
            }
            else
            {
                kid.GetComponent<Spawn>().enabled = true;
                kid.GetComponent<LightsOff>().enabled = true;
            }
            player.GetComponent<Rigidbody>().freezeRotation = false;
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            player.GetComponent<Movement>().enabled = true;
            player.GetComponent<Rotation>().enabled = true;
            player.GetComponent<Escape>().enabled = true;
            redStateActif = false;
            kidStateActif = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
