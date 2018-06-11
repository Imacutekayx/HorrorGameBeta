using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Escape : MonoBehaviour {
    public GameObject player;
    public GameObject playerLight;
    public GameObject kid;
    public GameObject red;
    public GameObject menu;
    public GameObject menuOptions;
    public AudioClip menuEscape;
    public AudioMixer music;
    public Slider musicVolume;

    public string key;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        playerLight = GameObject.FindWithTag("PlayerLight");
        kid = GameObject.FindWithTag("Kid");
        red = GameObject.FindWithTag("RedEyes");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(key))
        {
            StopGame();
        }
	}

    public void StopGame()
    {
        menu.GetComponent<AudioSource>().clip = menuEscape;
        Cursor.lockState = CursorLockMode.Confined;
        //Red
        red.GetComponent<Rigidbody>().freezeRotation = true;
        if (red.GetComponent<Pathfinding>().enabled)
        {
            red.GetComponent<Pathfinding>().enabled = false;
            red.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            menuOptions.GetComponent<ToOptions>().redStateActif = true;
        }

        //Kid
        kid.GetComponent<LightsOff>().enabled = false;
        if (kid.GetComponent<Spawn>().enabled == true)
        {
            kid.GetComponent<Spawn>().enabled = false;
        }
        else
        {
            kid.GetComponent<CheckSee>().enabled = false;
            menuOptions.GetComponent<ToOptions>().kidStateActif = true;
        }

        //Menu
        music.SetFloat("MusicVolume", musicVolume.value * 40 - 30);
        menu.SetActive(true);
        menuOptions.SetActive(true);

        //PlayerLight
        playerLight.GetComponent<ToggleLight>().enabled = false;

        //Player
        player.GetComponent<Rigidbody>().freezeRotation = true;
        player.GetComponent<Movement>().enabled = false;
        player.GetComponent<Rotation>().enabled = false;
        player.GetComponent<Escape>().enabled = false;
    }
}
