using UnityEngine;

/// <summary>
/// Script which enable the User to interact with the switch when the lights are off
/// </summary>
public class Switch : MonoBehaviour {

    //Objects
    public GameObject target;
    public GameObject red;
    public GameObject kid;
    public GameObject house;
    public GameObject musicPlayer;
    public GameObject creditCanvas;
    public Material green;
    public AudioClip bouton;
    public AudioClip lightOn;
    public AudioClip lightOnMusic;
    public AudioClip endingCreditMusic;
    private Renderer rend;
    private GameObject[] lights;

    //Variables
    public int maxRange;
    public int minRange;
    public KeyCode interact;
    public byte SwitchActived;


    //Use this for initialization
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        red = GameObject.FindWithTag("RedEyes");
        kid = GameObject.FindWithTag("Kid");
        house = GameObject.FindWithTag("Environnement");
        lights = GameObject.FindGameObjectsWithTag("Light");
        musicPlayer = GameObject.FindWithTag("Music");
        rend = GetComponent<Renderer>();
    }

    //Update is called once per frame
    void Update()
    {
        //Check if the Player is in area
        if ((Vector3.Distance(transform.position, target.transform.position) < maxRange)
           && (Vector3.Distance(transform.position, target.transform.position) > minRange))
        {
            //Check if the player press the InteractKey
            if (Input.GetKey(interact))
            {
                SwitchActived = GameObject.FindWithTag("S0").GetComponent<Switch>().SwitchActived;
                GetComponent<AudioSource>().clip = bouton;
                GetComponent<AudioSource>().Play();

                if (SwitchActived < 2)
                {
                    GameObject.FindWithTag("S0").GetComponent<Switch>().SwitchActived = ++SwitchActived;
                    red.GetComponent<Pathfinding>().enabled = false;
                    red.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                    red.transform.position = new Vector3(18.72f, 16.38f, -29.36f);

                    house.GetComponent<AudioSource>().clip = lightOn;
                    house.GetComponent<AudioSource>().Play();

                    //Enable all the lights
                    foreach (GameObject li in lights)
                    {
                        li.GetComponent<Light>().enabled = true;
                    }

                    rend.material = green;

                    kid.GetComponent<LightsOff>().on = true;
                    kid.GetComponent<LightsOff>().timer = 0;

                    musicPlayer.GetComponent<AudioSource>().clip = lightOnMusic;
                    musicPlayer.GetComponent<AudioSource>().Play();
                }
                else if(SwitchActived == 2)
                {
                    GameObject.FindWithTag("S0").GetComponent<Switch>().SwitchActived = ++SwitchActived;
                    StartCoroutine(kid.GetComponent<LightsOff>().Ends());
                }
                else
                {
                    target.GetComponent<Escape>().StopGame();
                    Cursor.lockState = CursorLockMode.Locked;
                    creditCanvas.SetActive(true);
                    creditCanvas.GetComponent<Credits>().chkDev = false;
                    creditCanvas.GetComponent<Credits>().chkMus = false;
                    creditCanvas.GetComponent<Credits>().chkSou = false;
                    creditCanvas.GetComponent<Credits>().chkThx = false;
                    creditCanvas.GetComponent<Credits>().chkCur = false;
                    creditCanvas.GetComponent<Credits>().enabled = true;
                    musicPlayer.GetComponent<AudioSource>().clip = endingCreditMusic;
                    musicPlayer.GetComponent<AudioSource>().Play();
                }
                GetComponent<Switch>().enabled = false;
            }
        }
    }
}
