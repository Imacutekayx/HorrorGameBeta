using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {
    public GameObject player;
    public GameObject kid;
    public GameObject red;
    public GameObject menu;
    public Camera mainCam;
    public Camera menuCam;
    public Material green;
    public GameObject menuOptions;
    public GameObject menuBase;

    private GameObject[] lights;

	public void StartingGame()
    {
        //Player
        player = GameObject.FindWithTag("Player");
        player.GetComponent<Movement>().enabled = true;
        player.GetComponent<Rotation>().enabled = true;
        player.GetComponent<Escape>().enabled = true;

        //Kid
        kid = GameObject.FindWithTag("Kid");
        kid.transform.SetPositionAndRotation(new Vector3(18f, 30f, -28f), Quaternion.Euler(0, 0, 0));
        kid.GetComponent<LightsOff>().enabled = true;
        kid.GetComponent<LightsOff>().timer = 0;
        kid.GetComponent<Spawn>().enabled = true;
        kid.GetComponent<Spawn>().timer = 0;
        kid.GetComponent<CheckSee>().enabled = false;

        //RedEyes
        red = GameObject.FindWithTag("RedEyes");
        red.transform.SetPositionAndRotation(new Vector3(18.72f, 15.52f, -29.36f), Quaternion.Euler(0, 0, 0));
        red.GetComponent<Pathfinding>().enabled = false;
        red.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

        //Lights
        lights = GameObject.FindGameObjectsWithTag("Light");
        foreach (GameObject li in lights)
        {
            li.GetComponent<Light>().enabled = true;
        }

        //Switches
        GameObject.FindWithTag("S0").GetComponent<Renderer>().material = green;
        GameObject.FindWithTag("S0").GetComponent<Switch>().enabled = false;
        GameObject.FindWithTag("S1").GetComponent<Renderer>().material = green;
        GameObject.FindWithTag("S1").GetComponent<Switch>().enabled = false;
        GameObject.FindWithTag("S2").GetComponent<Renderer>().material = green;
        GameObject.FindWithTag("S2").GetComponent<Switch>().enabled = false;

        //Menu
        menu = GameObject.FindWithTag("Menu");
        menu.SetActive(false);
        menuBase.SetActive(false);
        menuOptions.GetComponent<ToOptions>().inGame = true;

        //Cameras
        menuCam.enabled = false;
        mainCam.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
