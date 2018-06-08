using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {
    public GameObject player;
    public GameObject flashLight;
    public GameObject kid;
    public GameObject red;
    public GameObject menu;
    public GameObject menuOptions;
    public GameObject menuBase;
    public GameObject door;
    public GameObject house;
    public GameObject musicPlayer;
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
    private Animation playerAnim;
    private AudioSource doorSound;

    private void StartScene()
    {
        playerAnim.Play("enterHouse");
        doorSound.clip = door1;
        doorSound.Play();
        while (player.GetComponent<Animation>().IsPlaying("enterHouse")){}
        kid.transform.SetPositionAndRotation(new Vector3(), Quaternion.Euler(0, 0, 0));
        kid.transform.LookAt(player.transform);
        kid.GetComponent<AudioSource>().clip = IWill;
        kid.GetComponent<AudioSource>().Play();
        while (kid.GetComponent<AudioSource>().isPlaying){}
        doorSound.clip = door2;
        doorSound.Play();
        playerAnim.Play("watch01");
        while (player.GetComponent<Animation>().IsPlaying("watch01")) { }
        doorSound.clip = door3;
        playerAnim.Play("watch02");
        while (player.GetComponent<Animation>().IsPlaying("watch02")) { }
    }

    public void StartingGame()
    {
        //Lights
        lights = GameObject.FindGameObjectsWithTag("Light");
        foreach (GameObject li in lights)
        {
            li.GetComponent<Light>().enabled = true;
        }

        music.SetFloat("MusicVolume", -80f);

        player = GameObject.FindWithTag("Player");
        playerAnim = player.GetComponent<Animation>();
        playerAnim.AddClip(enterHouse, "enterHouse");
        playerAnim.AddClip(watch01, "watch01");
        playerAnim.AddClip(watch02, "watch02");
        kid = GameObject.FindWithTag("Kid");
        doorSound = door.GetComponent<AudioSource>();
        house = GameObject.FindWithTag("Environnement");
        red = GameObject.FindWithTag("RedEyes");
        red.transform.SetPositionAndRotation(new Vector3(18.72f, 15.52f, -29.36f), Quaternion.Euler(0, 0, 0));
        flashLight.transform.SetPositionAndRotation(new Vector3(0.2399998f, -2.22f, 1.642246f), Quaternion.Euler(90, 0, 0));

        //Menu
        menu.SetActive(false);
        menuBase.SetActive(false);
        menuOptions.GetComponent<ToOptions>().inGame = true;

        //Cameras
        menuCam.enabled = false;
        mainCam.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;

        //STARTSCENE
        //StartScene();

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

        //FlashLight
        flashLight.transform.SetPositionAndRotation(new Vector3(0.2399998f, -0.7800007f, 1.642246f), Quaternion.Euler(90, 0, 0));

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
    }
}
