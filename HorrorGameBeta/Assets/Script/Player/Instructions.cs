using UnityEngine;

/// <summary>
/// Script which show the instructions to the Player
/// </summary>
public class Instructions : MonoBehaviour {

    //Objects
    public GameObject target;
    public GameObject playerLight;
    public GameObject batteryBar;
    public GameObject instructions;
    public GameObject house;
    public AudioClip paperSound;

    //Variables
    public int maxRange;
    public int minRange;
    public KeyCode interact;
    private bool isActive;

    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("Player");
        playerLight = GameObject.FindWithTag("PlayerLight");
        house = GameObject.FindWithTag("Environnement");
	}
	
	// Update is called once per frame
	void Update () {
        //Check if the Player is in the area
        if((Vector3.Distance(transform.position, target.transform.position) < maxRange)
           && (Vector3.Distance(transform.position, target.transform.position) > minRange)){
            //Check if the player is pressing the InteractKey and if the instructions are enabled already
            if (Input.GetKeyDown(interact))
            {
                if (isActive)
                {
                    house.GetComponent<AudioSource>().clip = paperSound;
                    house.GetComponent<AudioSource>().Play();
                    isActive = false;
                    target.GetComponent<Movement>().enabled = true;
                    target.GetComponent<Escape>().enabled = true;
                    target.GetComponent<Rotation>().enabled = true;
                    target.GetComponent<Rigidbody>().freezeRotation = false;
                    target.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    playerLight.GetComponent<ToggleLight>().enabled = true;
                    batteryBar.SetActive(true);
                    instructions.SetActive(false);
                    GetComponent<Renderer>().enabled = true;
                }
                else
                {
                    house.GetComponent<AudioSource>().clip = paperSound;
                    house.GetComponent<AudioSource>().Play();
                    isActive = true;
                    target.GetComponent<Movement>().enabled = false;
                    target.GetComponent<Escape>().enabled = false;
                    target.GetComponent<Rotation>().enabled = false;
                    target.GetComponent<Rigidbody>().freezeRotation = true;
                    target.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                    playerLight.GetComponent<ToggleLight>().enabled = false;
                    batteryBar.SetActive(false);
                    instructions.SetActive(true);
                    GetComponent<Renderer>().enabled = false;
                }
            }
        }
	}
}
