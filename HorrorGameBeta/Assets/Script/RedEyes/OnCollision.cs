using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour {

    public GameObject player;
    public GameObject playerLight;
    public GameObject musicPlayer;
    public GameObject menu;
    public GameObject menuGameOver;
    public AudioClip killRed;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            player.GetComponent<Escape>().StopGame();
            musicPlayer.GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = killRed;
            GetComponent<AudioSource>().Play();
            player.transform.LookAt(new Vector3(0, 9000, 0));
            Cursor.lockState = CursorLockMode.Confined;
            menu.SetActive(true);
            menuGameOver.SetActive(true);
            GetComponent<CheckSee>().enabled = false;
        }
    }
}
