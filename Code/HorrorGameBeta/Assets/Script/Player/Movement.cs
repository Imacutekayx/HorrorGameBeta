﻿using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/// <summary>
/// Script that manages the movements of the Player
/// </summary>
public class Movement : MonoBehaviour {

    //Objects
    public AudioMixer sound;
    public AudioClip slow;
    public AudioClip walk;
    public AudioClip run;
    public Slider soundVolume;
    public GameObject red;
    public GameObject kid;
    private BoxCollider coll;
    private Vector3 tempVector;

    //Variables
    public KeyCode forward;
    public KeyCode behind;
    public KeyCode left;
    public KeyCode right;
    public KeyCode sprint;
    public KeyCode crouch;
    public KeyCode forwardBtn;
    public KeyCode behindBtn;
    public KeyCode leftBtn;
    public KeyCode rightBtn;
    public KeyCode sprintBtn;
    public KeyCode crouchBtn;
    public float speed;
    private readonly float translation;
    private readonly float straffe;
    private bool isCrouch = false;
    private bool isSprint = false;
    private bool allowSprint = true;
    private bool walking = false;

    //Use this for initialization
    void Start()
    {
        red = GameObject.FindWithTag("RedEyes");
        kid = GameObject.FindWithTag("Kid");
        coll = GetComponent<BoxCollider>();
    }

    //Update is called once per frame
    public void Update ()
    {
        //Croutch
        if ((Input.GetKey(crouch) || Input.GetKey(crouchBtn)) && !isCrouch)
        {
            //Check the sound volume before changing it
            if (soundVolume.value != 0 && GetComponent<AudioSource>().clip != slow)
            {
                GetComponent<AudioSource>().clip = slow;
                GetComponent<AudioSource>().Play();
                sound.SetFloat("PlayerVolume", soundVolume.value * 40 - 30);
            }
            isCrouch = true;
            allowSprint = false;
            coll.center = new Vector3(0f, 0f, 0f);
            transform.Translate(0, -4f, 0);
            speed /= 2f;
            red.GetComponent<AreaCheck>().playerState = 0;
        }
        else if ((!Input.GetKey(crouch) && !Input.GetKey(crouchBtn)) && isCrouch)
        {
            //Check the sound volume before changing it
            if (soundVolume.value != 0)
            {
                GetComponent<AudioSource>().clip = walk;
                GetComponent<AudioSource>().Play();
                sound.SetFloat("PlayerVolume", soundVolume.value * 40 - 20);
            }
            isCrouch = false;
            allowSprint = true;
            transform.Translate(0, 4f, 0);
            coll.center = new Vector3(0f, -3f, 0f);
            speed *= 2f;
            red.GetComponent<AreaCheck>().playerState = 1;
        }

        //Sprint
        if ((Input.GetKey(sprint) || Input.GetKey(sprintBtn)) && allowSprint && !isSprint)
        {
            //Check the sound volume before changing it
            if (soundVolume.value != 0 && GetComponent<AudioSource>().clip != run)
            {
                GetComponent<AudioSource>().clip = run;
                GetComponent<AudioSource>().Play();
                sound.SetFloat("PlayerVolume", soundVolume.value * 40 - 10);
            }
            isSprint = true;
            speed *= 2f;
            red.GetComponent<AreaCheck>().playerState = 2;
        }
        else if ((!Input.GetKey(sprint) && !Input.GetKey(sprintBtn)) && isSprint)
        {
            //Check the sound volume before changing it
            if (soundVolume.value != 0)
            {
                GetComponent<AudioSource>().clip = walk;
                GetComponent<AudioSource>().Play();
                sound.SetFloat("PlayerVolume", soundVolume.value * 40 - 20);
            }
            isSprint = false;
            speed /= 2f;
            red.GetComponent<AreaCheck>().playerState = 1;
        }

        //Basic movement
        if(((Input.GetKey(forward) || Input.GetKey(left) || Input.GetKey(behind) || Input.GetKey(right))
            || (Input.GetAxis("Vertical") == 1 || Input.GetAxis("Horizontal") == -1 || Input.GetAxis("Vertical") == -1 || Input.GetAxis("Horizontal") == 1))
            && !walking)
        {
            //Check the component LightsOff of Kid and enable the component AreaCheck of RedEyes if true
            if (!kid.GetComponent<LightsOff>().enabled)
            {
                red.GetComponent<AreaCheck>().enabled = true;
            }
            walking = true;
            GetComponent<AudioSource>().loop = true;
            GetComponent<AudioSource>().Play();
        }
        else if (((!Input.GetKey(forward) && !Input.GetKey(left) && !Input.GetKey(behind) && !Input.GetKey(right))
            && (Input.GetAxis("Vertical") != 1 && Input.GetAxis("Horizontal") != -1 && Input.GetAxis("Vertical") != -1 && Input.GetAxis("Horizontal") != 1))
            && walking)
        {
            //Check the component LightsOff of Kid and disable the component AreaCheck of RedEyes if true
            if (!kid.GetComponent<LightsOff>().enabled)
            {
                red.GetComponent<AreaCheck>().enabled = false;
            }
            walking = false;
            GetComponent<AudioSource>().loop = false;
            GetComponent<AudioSource>().Stop();
        }

        //Movements
        if (Input.GetKey(forward) || Input.GetAxis("Vertical") == 1)
        {
            tempVector = transform.rotation * Vector3.forward * Time.deltaTime * speed;
            transform.position += tempVector;
        }
        if (Input.GetKey(behind) || Input.GetAxis("Vertical") == -1)
        {
            tempVector = transform.rotation * Vector3.forward * Time.deltaTime * speed;
            transform.position -= tempVector;
        }
        if (Input.GetKey(right) || Input.GetAxis("Horizontal") == 1)
        {
            tempVector = transform.rotation * Vector3.right * Time.deltaTime * speed;
            transform.position += tempVector;
        }
        if (Input.GetKey(left) || Input.GetAxis("Horizontal") == -1)
        {
            tempVector = transform.rotation * Vector3.right * Time.deltaTime * speed;
            transform.position -= tempVector;
        }
    }
}
