using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            player.transform.LookAt(new Vector3(0, 9000, 0));
            //TODO Play KillRed
            player.GetComponent<Movement>().enabled = false;
            player.GetComponent<Rotation>().enabled = false;
            GetComponent<CheckSee>().enabled = false;
        }
    }
}
