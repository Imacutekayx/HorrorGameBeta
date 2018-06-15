using UnityEngine;

/// <summary>
/// Script that analyse if the player look at the Kid with the PlayerLight on and kill him if not for 5 seconds
/// </summary>
public class CheckSee : MonoBehaviour {

    //Objects
    public GameObject player;
    public GameObject playerLight;
    public GameObject musicPlayer;
    public GameObject menuGameOver;
    public GameObject menuOptions;
    public GameObject menu;
    public GameObject userLayout;
    public GameObject battery;
    public AudioClip killKid;
    private Light spot;

    //Variables
    public bool isLookedAt = false;
    public float killCount;
    public float safeCount;

	//Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        playerLight = GameObject.FindWithTag("PlayerLight");
        spot = playerLight.GetComponent<Light>();
        killCount = 0;
        safeCount = 0;
	}
	
	//Update is called once per frame
	void Update () {
        transform.LookAt(player.transform);

        //Check if the player is looking at the Kid and if the PlayerLight is enabled
        if (isLookedAt && spot.enabled == true)
        {
            ++safeCount;
            if(safeCount * Time.deltaTime > 5)
            {
                transform.SetPositionAndRotation(new Vector3(18f, 30f, -28f), Quaternion.Euler(0, 0, 0));
                GetComponent<Spawn>().timer = 0;
                GetComponent<Spawn>().enabled = true;
                GetComponent<CheckSee>().enabled = false;
            }
        }
        else
        {
            ++killCount;
            if(killCount * Time.deltaTime > 5)
            {
                killCount = 0;
                safeCount = 0;
                player.GetComponent<Escape>().StopGame();
                musicPlayer.GetComponent<AudioSource>().Stop();
                player.transform.LookAt(new Vector3(0, 9000, 0));
                GetComponent<AudioSource>().clip = killKid;
                GetComponent<AudioSource>().Play();
                menu.SetActive(true);
                menuOptions.SetActive(false);
                menuGameOver.SetActive(true);
                userLayout.SetActive(false);
                battery.transform.SetPositionAndRotation(new Vector3(22f, -22f, -10f), Quaternion.Euler(90, 90, 0));
                GetComponent<CheckSee>().enabled = false;
            }
        }
    }
}
