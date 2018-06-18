using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/// <summary>
/// Script that will reset the game
/// </summary>
public class StartGame : MonoBehaviour {

    //Objects
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
    public AudioClip thunder;
    public AudioClip notLightOn;
    public Slider musicVolume;
    public AnimationClip enterHouse;
    public AnimationClip watch01;
    public AnimationClip watch02;
    private GameObject[] lights;
    private Animator playerAnimator;
    private AudioSource doorSound;

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
        player.transform.SetPositionAndRotation(new Vector3(18.72f, 6.01f, -27.03f), Quaternion.identity);
        playerLight = GameObject.FindWithTag("PlayerLight");
        playerLight.GetComponent<Light>().enabled = true;
        playerAnimator = player.GetComponent<Animator>();
        kid = GameObject.FindWithTag("Kid");
        doorSound = door.GetComponent<AudioSource>();
        house = GameObject.FindWithTag("Environnement");
        red = GameObject.FindWithTag("RedEyes");
        red.transform.SetPositionAndRotation(new Vector3(18.72f, 15.52f, -29.36f), Quaternion.identity);

        //Menu
        menu.GetComponent<Canvas>().enabled = false;
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
            StartCoroutine(StartScene());
        }
        else
        {
            ResetParams();
        }
    }

    /// <summary>
    /// Method that will play an animation
    /// </summary>
    private IEnumerator StartScene()
    {
        //Animation
        playerAnimator.enabled = true;
        playerAnimator.Play("EnterHouse");
        doorSound.clip = door1;
        doorSound.Play();
        yield return new WaitForSeconds(playerAnimator.GetCurrentAnimatorClipInfo(0).Length + 1);
        house.GetComponent<AudioSource>().clip = thunder;
        house.GetComponent<AudioSource>().Play();
        kid.transform.SetPositionAndRotation(new Vector3(18.67f, 7.17f, -11.79f), Quaternion.Euler(0, 0, 0));
        kid.transform.LookAt(player.transform);
        kid.GetComponent<AudioSource>().clip = IWill;
        kid.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(kid.GetComponent<AudioSource>().clip.length);
        doorSound.clip = door2;
        doorSound.Play();
        playerAnimator.SetBool("PlayWatch1", true);
        yield return new WaitForSeconds(playerAnimator.GetCurrentAnimatorClipInfo(0).Length);
        kid.transform.SetPositionAndRotation(new Vector3(18f, 30f, -28f), Quaternion.Euler(0, 0, 0));
        doorSound.clip = door3;
        doorSound.Play();
        yield return new WaitForSeconds(1);
        playerAnimator.SetBool("PlayWatch2", true);
        yield return new WaitForSeconds(playerAnimator.GetCurrentAnimatorClipInfo(0).Length + 1);
        house.GetComponent<AudioSource>().clip = notLightOn;
        house.GetComponent<AudioSource>().Play();
        ResetParams();
    }

    /// <summary>
    /// Method which reset the parameters of the game
    /// </summary>
    private void ResetParams()
    {
        //Menu
        menu.GetComponent<Canvas>().enabled = true;
        menu.SetActive(false);
        menuBase.SetActive(false);

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

        //PlayerAnimator
        playerAnimator.enabled = false;
        playerAnimator.SetBool("PlayWatch1", false);
        playerAnimator.SetBool("PlayWatch2", false);

        //PlayerLight
        playerLight.GetComponent<Light>().enabled = false;
        playerLight.GetComponent<ToggleLight>().timer = 0;
        playerLight.GetComponent<ToggleLight>().batteryTime = 100;
        playerLight.GetComponent<ToggleLight>().enabled = true;

        //Kid
        kid.SetActive(true);
        kid.transform.SetPositionAndRotation(new Vector3(18f, 30f, -28f), Quaternion.Euler(0, 0, 0));
        kid.GetComponent<LightsOff>().timer = 0;
        kid.GetComponent<LightsOff>().on = true;
        kid.GetComponent<LightsOff>().enabled = true;
        kid.GetComponent<Spawn>().timer = 0;
        kid.GetComponent<Spawn>().x = 23.7f;
        kid.GetComponent<Spawn>().y = 2.79f;
        kid.GetComponent<Spawn>().z = 16.1f;
        kid.GetComponent<Spawn>().enabled = true;
        kid.GetComponent<CheckSee>().enabled = false;

        //RedEyes
        red.SetActive(true);
        red.GetComponent<Rigidbody>().freezeRotation = false;
        red.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        red.GetComponent<Pathfinding>().enabled = false;
        red.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

        //Switches
        GameObject.FindWithTag("S0").GetComponent<Renderer>().material = green;
        GameObject.FindWithTag("S0").GetComponent<Switch>().enabled = false;
        GameObject.FindWithTag("S0").GetComponent<Switch>().SwitchActived = 2;
        GameObject.FindWithTag("S1").GetComponent<Renderer>().material = green;
        GameObject.FindWithTag("S1").GetComponent<Switch>().enabled = false;
        GameObject.FindWithTag("S2").GetComponent<Renderer>().material = green;
        GameObject.FindWithTag("S2").GetComponent<Switch>().enabled = false;

        //UserLayout
        userLayout.SetActive(true);
        batteryBar.GetComponent<Slider>().value = 100;
        batteryBar.SetActive(true);
        instructions.SetActive(false);

        //InstructionsPaper
        instructionsPaper.GetComponent<Renderer>().enabled = true;
    }
}
