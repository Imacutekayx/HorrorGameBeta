using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Script that analyse the Player's state and position and manage the Chase component of RedEyes
/// </summary>
public class AreaCheck : MonoBehaviour {

    //Objects
    public GameObject player;
    public GameObject kid;

    //Variables
    public byte playerState = 1;
    public bool isInArea = false;

	//Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        kid = GameObject.FindWithTag("Kid");
	}
	
	//Update is called once per frame
	void Update ()
    {
        //Check if the lights are off
        if (!kid.GetComponent<LightsOff>().enabled)
        {
            //Check the state of the Player to manage the Chase
            switch (playerState)
            {
                //Crouch
                case 0:
                    {
                        if (!isInArea && GetComponent<Chase>().enabled)
                        {
                            GetComponent<Chase>().enabled = false;
                            GetComponent<Pathfinding>().enabled = true;
                            GetComponent<NavMeshAgent>().speed = 7.5f;
                        }
                        break;
                    }
                //Walk
                case 1:
                    {
                        if (isInArea && !GetComponent<Chase>().enabled)
                        {
                            GetComponent<Chase>().enabled = true;
                            GetComponent<NavMeshAgent>().speed = 17.5f;
                        }
                        break;
                    }
                //Run
                case 2:
                    {
                        if (!GetComponent<Chase>().enabled)
                        {
                            GetComponent<Chase>().enabled = true;
                            GetComponent<NavMeshAgent>().speed = 17.5f;
                        }
                        break;
                    }
            }
        }
	}
}
