using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Movement : MonoBehaviour {
    
    public float speed = 2.5f;
    private float translation;
    private float straffe;
    private bool croutch = false;
    private bool sprint = false;
    private bool allowSprint = true;
    private bool walking = false;

    public AudioMixer sound;
    public AudioClip crouch;
    public AudioClip walk;
    public AudioClip run;
    public Slider soundVolume;
    private CapsuleCollider coll;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        coll = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    public void Update ()
    {
        //Croutch
        if (Input.GetKey("left ctrl"))
        {
            if (soundVolume.value != 0 && player.GetComponent<AudioSource>().clip != crouch)
            {
                player.GetComponent<AudioSource>().clip = crouch;
                sound.SetFloat("PlayerVolume", soundVolume.value * 40 - 30);
            }
            croutch = true;
            allowSprint = false;
            coll.height = 1.5f;
            transform.Translate(0, -0.1f, 0);
            speed /= 2f;
        }
        else if (croutch)
        {
            if (soundVolume.value != 0)
            {
                player.GetComponent<AudioSource>().clip = walk;
                sound.SetFloat("PlayerVolume", soundVolume.value * 40 - 20);
            }
            croutch = false;
            allowSprint = true;
            coll = GetComponent<CapsuleCollider>();
            transform.Translate(0, 2.5f, 0);
            coll.height = 5f;
            speed *= 2f;
        }

        //Sprint
        if (Input.GetKey("left shift") && allowSprint && !sprint)
        {
            if(soundVolume.value != 0 && player.GetComponent<AudioSource>().clip != run)
            {
                player.GetComponent<AudioSource>().clip = run;
                sound.SetFloat("PlayerVolume", soundVolume.value * 40 - 10);
            }
            sprint = true;
            speed *= 4f;
        }
        else if (sprint)
        {
            if(soundVolume.value != 0)
            {
                player.GetComponent<AudioSource>().clip = walk;
                sound.SetFloat("PlayerVolume", soundVolume.value * 40 - 20);
            }
            sprint = false;
            speed /= 4f;
        }

        if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d") && !walking)
        {
            walking = true;
            player.GetComponent<AudioSource>().enabled = true;
            player.GetComponent<AudioSource>().Play();
        }
        else if (walking)
        {
            walking = false;
            player.GetComponent<AudioSource>().enabled = false;
        }

        //Movements
        translation = Input.GetAxis("Vertical") * speed;
        straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);
    }
}
