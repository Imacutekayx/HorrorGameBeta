using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/// <summary>
/// Script that will manage the options' buttons
/// </summary>
public class ToOptions : MonoBehaviour {

    //Objects
    public GameObject menu;
    public GameObject panelMenu;
    public GameObject panelOptions;
    public GameObject kid;
    public GameObject red;
    public GameObject player;
    public GameObject playerLight;
    public GameObject musicPlayer;
    public GameObject menuGameOver;
    public GameObject battery;
    public Camera mainCam;
    public Camera menuCam;
    public AudioMixer music;
    public AudioClip menuMusic;
    public Slider musicVolume;

    //Variables
    public bool redStateActif;
    public bool kidStateActif;
    public bool inGame = false;

	//Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        playerLight = GameObject.FindWithTag("PlayerLight");
        kid = GameObject.FindWithTag("Kid");
        red = GameObject.FindWithTag("RedEyes");
        musicPlayer = GameObject.FindWithTag("Music");
    }

    /// <summary>
    /// Method that go back to the main menu
    /// </summary>
    public void ToMenu()
    {
        //Check if the User is in game and reset the parameters to have a clear scene
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
            menuGameOver.SetActive(false);
            battery.transform.SetPositionAndRotation(new Vector3(22f, -22f, -10f), Quaternion.Euler(90, 90, 0));
        }
        panelOptions.SetActive(false);
        panelMenu.SetActive(true);
    }

    /// <summary>
    /// Method that validate the parameters and close the options panel
    /// </summary>
    public void Validate()
    {
        //Check if the User is in a game and go back to the menu or continue the game
        if(kid.transform.position == new Vector3(2.34f, 3.62f, -1.27f))
        {
            ToMenu();
        }
        else
        {
            music.SetFloat("MusicVolume", musicVolume.value * 40 - 20);
            menu.SetActive(false);
            panelOptions.SetActive(false);
            //Check the state of RedEyes before the escape
            if (redStateActif)
            {
                red.GetComponent<Pathfinding>().enabled = true;
                red.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
            }
            //Check the state of Kid before the escape
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
            playerLight.GetComponent<ToggleLight>().enabled = true;
            redStateActif = false;
            kidStateActif = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
