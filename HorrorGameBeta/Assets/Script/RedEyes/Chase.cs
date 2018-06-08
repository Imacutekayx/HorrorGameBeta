using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour {
    public GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Pathfinding>().enabled = false;
        GetComponent<NavMeshAgent>().destination = player.transform.position;
	}
}
