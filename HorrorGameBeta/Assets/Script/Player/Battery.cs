using UnityEngine;

/// <summary>
/// Script which enable the User to interact with the battery
/// </summary>
public class Battery : MonoBehaviour {

    //Objects
    public GameObject lightPlayer;
    public GameObject target;

    //Variables
    public int maxRange;
    public int minRange;
    public KeyCode interact;

    //Use this for initialization
    private void Start()
    {
        lightPlayer = GameObject.FindWithTag("PlayerLight");
        target = GameObject.FindWithTag("Player");
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
                lightPlayer.GetComponent<ToggleLight>().timer = 0;
                transform.SetPositionAndRotation(new Vector3(22f, -22f, -10f), Quaternion.Euler(90, 90, 0));
            }
        }
    }
}
