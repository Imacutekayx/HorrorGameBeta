using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Movement : MonoBehaviour {
    
    public float speed;
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
    public GameObject red;
    public GameObject kid;
    private CapsuleCollider coll;

    void Start()
    {
        red = GameObject.FindWithTag("RedEyes");
        kid = GameObject.FindWithTag("Kid");
        coll = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    public void Update ()
    {
        //Croutch
        if (Input.GetKey("left ctrl") && !croutch)
        {
            if (soundVolume.value != 0 && GetComponent<AudioSource>().clip != crouch)
            {
                GetComponent<AudioSource>().clip = crouch;
                sound.SetFloat("PlayerVolume", soundVolume.value * 40 - 30);
            }
            croutch = true;
            allowSprint = false;
            coll.height = 1.5f;
            transform.Translate(0, -0.1f, 0);
            speed /= 2f;
            red.GetComponent<AreaCheck>().playerState = 0;
        }
        else if (!Input.GetKey("left ctrl") && croutch)
        {
            if (soundVolume.value != 0)
            {
                GetComponent<AudioSource>().clip = walk;
                sound.SetFloat("PlayerVolume", soundVolume.value * 40 - 20);
            }
            croutch = false;
            allowSprint = true;
            coll = GetComponent<CapsuleCollider>();
            transform.Translate(0, 2.5f, 0);
            coll.height = 5f;
            speed *= 2f;
            red.GetComponent<AreaCheck>().playerState = 1;
        }

        //Sprint
        if (Input.GetKey("left shift") && allowSprint && !sprint)
        {
            if(soundVolume.value != 0 && GetComponent<AudioSource>().clip != run)
            {
                GetComponent<AudioSource>().clip = run;
                sound.SetFloat("PlayerVolume", soundVolume.value * 40 - 10);
            }
            sprint = true;
            speed *= 2f;
            red.GetComponent<AreaCheck>().playerState = 2;
        }
        else if (!Input.GetKey("left shift") && sprint)
        {
            if(soundVolume.value != 0)
            {
                GetComponent<AudioSource>().clip = walk;
                sound.SetFloat("PlayerVolume", soundVolume.value * 40 - 20);
            }
            sprint = false;
            speed /= 2f;
            red.GetComponent<AreaCheck>().playerState = 1;
        }

        if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d") && !walking)
        {
            if (!kid.GetComponent<LightsOff>().enabled)
            {
                red.GetComponent<AreaCheck>().enabled = true;
            }
            walking = true;
            GetComponent<AudioSource>().Play();
        }
        else if (!Input.GetKey("w") && !Input.GetKey("a") && !Input.GetKey("s") && !Input.GetKey("d") && walking)
        {
            if (!kid.GetComponent<LightsOff>().enabled)
            {
                red.GetComponent<AreaCheck>().enabled = false;
            }
            walking = false;
        }

        //Movements
        translation = Input.GetAxis("Vertical") * speed;
        straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);
    }
}
