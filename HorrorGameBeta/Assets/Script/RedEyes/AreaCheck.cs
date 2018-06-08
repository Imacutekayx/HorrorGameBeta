using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AreaCheck : MonoBehaviour {
    public GameObject player;

    public byte playerState = 1;
    public bool isInArea = false;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        switch (playerState)
        {
            case 0:
                {
                    if(!isInArea && GetComponent<Chase>().enabled)
                    {
                        GetComponent<Chase>().enabled = false;
                        GetComponent<Pathfinding>().enabled = true;
                        GetComponent<NavMeshAgent>().speed = 7.5f;
                    }
                    break;
                }
            case 1:
                {
                    if(isInArea && !GetComponent<Chase>().enabled)
                    {
                        GetComponent<Chase>().enabled = true;
                        GetComponent<NavMeshAgent>().speed = 17.5f;
                    }
                    break;
                }
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
