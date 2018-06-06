using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour {
    public GameObject player;
    public GameObject kid;
    public GameObject red;
    public GameObject menu;
    public GameObject menuOptions;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        kid = GameObject.FindWithTag("Kid");
        red = GameObject.FindWithTag("RedEyes");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape"))
        {
            Cursor.lockState = CursorLockMode.Confined;
            //Red
            red.GetComponent<Rigidbody>().freezeRotation = true;
            if (red.GetComponent<Pathfinding>().enabled)
            {
                red.GetComponent<Pathfinding>().enabled = false;
                red.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                menuOptions.GetComponent<ToOptions>().redStateActif = true;
            }

            //Kid
            kid.GetComponent<LightsOff>().enabled = false;
            if(kid.GetComponent<Spawn>().enabled == true)
            {
                kid.GetComponent<Spawn>().enabled = false;
            }
            else
            {
                kid.GetComponent<CheckSee>().enabled = false;
                menuOptions.GetComponent<ToOptions>().kidStateActif = true;
            }

            //Menu
            menu.SetActive(true);
            menuOptions.SetActive(true);

            //Player
            player.GetComponent<Rigidbody>().freezeRotation = true;
            player.GetComponent<Movement>().enabled = false;
            player.GetComponent<Rotation>().enabled = false;
            player.GetComponent<Escape>().enabled = false;
        }
	}
}
