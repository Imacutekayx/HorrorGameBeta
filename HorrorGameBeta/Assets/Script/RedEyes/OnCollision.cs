using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour {

    public GameObject player;
    public GameObject musicPlayer;
    public AudioClip killRed;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        musicPlayer = GameObject.FindWithTag("Music");
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            musicPlayer.GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = killRed;
            GetComponent<AudioSource>().Play();
            player.transform.LookAt(new Vector3(0, 9000, 0));
            player.GetComponent<Movement>().enabled = false;
            player.GetComponent<Rotation>().enabled = false;
            GetComponent<CheckSee>().enabled = false;
        }
    }
}
