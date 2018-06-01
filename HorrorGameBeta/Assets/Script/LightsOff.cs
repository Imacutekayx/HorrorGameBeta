using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsSwitch : MonoBehaviour {

    public int timer = 0;
    public bool on = true;

    private GameObject[] lights;
    public GameObject red;

	// Use this for initialization
	void Start ()
    {
        lights = GameObject.FindGameObjectsWithTag("Light");
        red = GameObject.FindWithTag("RedEyes");
    }

    private void Update()
    {
        if(timer*Time.deltaTime == 60 && on)
        {
            on = false;

            foreach (GameObject li in lights)
            {
                li.GetComponent<Light>().enabled = false;
            }

            red.GetComponent<Pathfinding>().enabled = true;
        }
        else
        {
            ++timer;
        }
    }
}
