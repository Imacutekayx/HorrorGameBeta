using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/// <summary>
/// Script that will reset the game
/// </summary>
public class StartGame : MonoBehaviour {

    //objects
    public GameObject player;
    public GameObject playerLight;
    public GameObject flashLight;
    public GameObject kid;
    public GameObject red;
    public GameObject menu;
    public GameObject menuOptions;
    public GameObject menuBase;
    public GameObject menuGameOver;
    public GameObject userLayout;
    public GameObject door;
    public GameObject house;
    public GameObject musicPlayer;
    public GameObject batteryBar;
    public GameObject instructions;
    public GameObject instructionsPaper;
    public Camera mainCam;
    public Camera menuCam;
    public Material green;
    public AudioMixer music;
    public AudioClip lightOn;
    public AudioClip door1;
    public AudioClip door2;
    public AudioClip door3;
    public AudioClip IWill;
    public Slider musicVolume;
    public AnimationClip enterHouse;
    public AnimationClip watch01;
    public AnimationClip watch02;
    private GameObject[] lights;
    private Animator playerAnimator;
    private AudioSource doorSound;

    /// <summary>
    /// Method that will play an animation
    /// </summary>
    private void StartScene()
    {
        //TODO Animation
        playerAnimator.Play("Entry");
        doorSound.clip = door1;
        doorSound.Play();
        //while (playerAnimator.anima){}
        //TODO Thunder
        kid.transform.SetPositionAndRotation(new Vector3(), Quaternion.Euler(0, 0, 0));
        kid.transform.LookAt(player.transform);
        kid.GetComponent<AudioSource>().clip = IWill;
        kid.GetComponent<AudioSource>().Play();
        while (kid.GetComponent<AudioSource>().isPlaying){}
        doorSound.clip = door2;
        doorSound.Play();
        playerAnimator.Play("Watch1");
        //while (player.GetComponent<Animation>().IsPlaying("watch01")) { }
        kid.transform.SetPositionAndRotation(new Vector3(18f, 30f, -28f), Quaternion.Euler(0, 0, 0));
        doorSound.clip = door3;
        playerAnimator.Play("Watch2");
        //while (player.GetComponent<Animation>().IsPlaying("watch02")) { }
    }

    /// <summary>
    /// Method that reset the game parameters
    /// </summary>
    /// <param name="retry">Boolean to check if this is a retry or a first try</param>
    public void StartingGame(bool retry)
    {
        //Lights
        lights = GameObject.FindGameObjectsWithTag("Light");
        foreach (GameObject li in lights)
        {
            li.GetComponent<Light>().enabled = true;
        }

        music.SetFloat("MusicVolume", -80f);

        //GameObjects needed for the animation
        player = GameObject.FindWithTag("Player");
        player.transform.SetPositionAndRotation(new Vector3(18.72f, 6.23f, -32.03f), Quaternion.Euler(0, 0, 0));
        playerLight = GameObject.FindWithTag("PlayerLight");
        playerLight.GetComponent<Light>().enabled = false;
        playerAnimator = player.GetComponent<Animator>();
        kid = GameObject.FindWithTag("Kid");
        doorSound = door.GetComponent<AudioSource>();
        house = GameObject.FindWithTag("Environnement");
        red = GameObject.FindWithTag("RedEyes");
        red.transform.SetPositionAndRotation(new Vector3(18.72f, 15.52f, -29.36f), Quaternion.Euler(0, 0, 0));
        flashLight.transform.SetPositionAndRotation(new Vector3(19.15f, 4.3f, -30.14f), Quaternion.Euler(90, 0, 0));

        //Menu
        menu.SetActive(false);
        menuBase.SetActive(false);
        menuGameOver.SetActive(false);
        menuOptions.GetComponent<ToOptions>().inGame = true;

        //Cameras
        menuCam.enabled = false;
        mainCam.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;

        //STARTSCENE
        //Check if this is a retry
        if (!retry)
        {
            StartScene();
        }

        //Music
        musicPlayer = GameObject.FindWithTag("Music");
        musicPlayer.GetComponent<AudioSource>().clip = lightOn;
        musicPlayer.GetComponent<AudioSource>().Play();
        music.SetFloat("MusicVolume", musicVolume.value * 40 - 20);
        
        //Player
        player.GetComponent<Movement>().enabled = true;
        player.GetComponent<Rotation>().enabled = true;
        player.GetComponent<Escape>().enabled = true;
        player.GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<Rigidbody>().freezeRotation = false;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        //PlayerLight
        playerLight.GetComponent<ToggleLight>().enabled = true;
        playerLight.GetComponent<ToggleLight>().timer = 0;

        //FlashLight
        flashLight.transform.SetPositionAndRotation(new Vector3(19.15f, 5.3f, -30.14f), Quaternion.Euler(90, 0, 0));

        //Kid
        kid.transform.SetPositionAndRotation(new Vector3(18f, 30f, -28f), Quaternion.Euler(0, 0, 0));
        kid.GetComponent<LightsOff>().enabled = true;
        kid.GetComponent<LightsOff>().timer = 0;
        kid.GetComponent<Spawn>().enabled = true;
        kid.GetComponent<Spawn>().timer = 0;
        kid.GetComponent<CheckSee>().enabled = false;

        //RedEyes
        red.GetComponent<Rigidbody>().freezeRotation = false;
        red.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        red.GetComponent<Pathfinding>().enabled = false;
        red.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        
        //Switches
        GameObject.FindWithTag("S0").GetComponent<Renderer>().material = green;
        GameObject.FindWithTag("S0").GetComponent<Switch>().enabled = false;
        GameObject.FindWithTag("S1").GetComponent<Renderer>().material = green;
        GameObject.FindWithTag("S1").GetComponent<Switch>().enabled = false;
        GameObject.FindWithTag("S2").GetComponent<Renderer>().material = green;
        GameObject.FindWithTag("S2").GetComponent<Switch>().enabled = false;

        //UserLayout
        userLayout.SetActive(true);
        batteryBar.SetActive(true);
        instructions.SetActive(false);

        //InstructionsPaper
        instructionsPaper.GetComponent<Renderer>().enabled = true;
    }
}
