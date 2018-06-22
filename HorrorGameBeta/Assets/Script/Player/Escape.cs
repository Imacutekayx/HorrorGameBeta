using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/// <summary>
/// Script that active the OptionMenu during the game
/// </summary>
public class Escape : MonoBehaviour {

    //Objects
    public GameObject player;
    public GameObject playerLight;
    public GameObject kid;
    public GameObject red;
    public GameObject menu;
    public GameObject menuOptions;
    public GameObject userLayout;
    public GameObject newCurrentBtn;
    public AudioClip menuEscape;
    public AudioMixer music;
    public Slider musicVolume;

    //Variable
    public KeyCode key;
    public KeyCode button;
    private float timer;

	//Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        playerLight = GameObject.FindWithTag("PlayerLight");
        kid = GameObject.FindWithTag("Kid");
        red = GameObject.FindWithTag("RedEyes");
	}
	
	//Update is called once per frame
	void Update () {
        //Check if the User press the EscapeKey
        if (++timer*Time.deltaTime > 0.5 && (Input.GetKeyDown(key) || Input.GetKeyDown(button)))
        {
            timer = 0;
            StopGame();
        }
	}

    /// <summary>
    /// Method which stop the scripts in the game to make it pause
    /// </summary>
    public void StopGame()
    {
        menu.GetComponent<AudioSource>().clip = menuEscape;

        //Red
        red.GetComponent<Rigidbody>().freezeRotation = true;
        //Check the state of the RedEyes
        if (red.GetComponent<Pathfinding>().enabled)
        {
            red.GetComponent<Pathfinding>().enabled = false;
            red.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            menuOptions.GetComponent<ToOptions>().redStateActif = true;
        }
        else
        {
            menuOptions.GetComponent<ToOptions>().redStateActif = false;
        }

        //Kid
        kid.GetComponent<LightsOff>().enabled = false;
        //Check the state of the RedEyes
        if (kid.GetComponent<Spawn>().enabled == true)
        {
            kid.GetComponent<Spawn>().enabled = false;
            menuOptions.GetComponent<ToOptions>().kidStateActif = false;
        }
        else
        {
            kid.GetComponent<CheckSee>().enabled = false;
            menuOptions.GetComponent<ToOptions>().kidStateActif = true;
        }

        //Menu
        music.SetFloat("MusicVolume", musicVolume.value * 40 - 30);
        menu.SetActive(true);
        menu.GetComponent<MenuController>().SetNewBtn(true);
        menu.GetComponent<MenuController>().localLayer = 1;
        menu.GetComponent<MenuController>().currentBtn = newCurrentBtn;
        menu.GetComponent<MenuController>().SetNewBtn(false);
        menuOptions.SetActive(true);
        userLayout.SetActive(false);

        //PlayerLight
        playerLight.GetComponent<ToggleLight>().enabled = false;

        //Player
        player.GetComponent<Rigidbody>().freezeRotation = true;
        player.GetComponent<Movement>().enabled = false;
        player.GetComponent<AudioSource>().Stop();
        player.GetComponent<Rotation>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        player.GetComponent<Escape>().enabled = false;
    }
}
