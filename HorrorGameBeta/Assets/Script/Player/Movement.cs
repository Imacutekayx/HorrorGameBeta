using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Movement : MonoBehaviour {
    
    public float speed;
    public string forward;
    public string behind;
    public string left;
    public string right;
    public string sprint;
    public string crouch;
    private float translation;
    private float straffe;
    private bool isCrouch = false;
    private bool isSprint = false;
    private bool allowSprint = true;
    private bool walking = false;
    private bool loop = false;

    public AudioMixer sound;
    public AudioClip slow;
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
        if (Input.GetKey(crouch) && !isCrouch)
        {
            if (soundVolume.value != 0 && GetComponent<AudioSource>().clip != slow)
            {
                GetComponent<AudioSource>().clip = slow;
                sound.SetFloat("PlayerVolume", soundVolume.value * 40 - 30);
            }
            isCrouch = true;
            allowSprint = false;
            coll.height = 1.5f;
            transform.Translate(0, -0.1f, 0);
            speed /= 2f;
            red.GetComponent<AreaCheck>().playerState = 0;
        }
        else if (!Input.GetKey(crouch) && isCrouch)
        {
            if (soundVolume.value != 0)
            {
                GetComponent<AudioSource>().clip = walk;
                sound.SetFloat("PlayerVolume", soundVolume.value * 40 - 20);
            }
            isCrouch = false;
            allowSprint = true;
            coll = GetComponent<CapsuleCollider>();
            transform.Translate(0, 2.5f, 0);
            coll.height = 5f;
            speed *= 2f;
            red.GetComponent<AreaCheck>().playerState = 1;
        }

        //Sprint
        if (Input.GetKey(sprint) && allowSprint && !isSprint)
        {
            if(soundVolume.value != 0 && GetComponent<AudioSource>().clip != run)
            {
                GetComponent<AudioSource>().clip = run;
                sound.SetFloat("PlayerVolume", soundVolume.value * 40 - 10);
            }
            isSprint = true;
            speed *= 2f;
            red.GetComponent<AreaCheck>().playerState = 2;
        }
        else if (!Input.GetKey(sprint) && isSprint)
        {
            if(soundVolume.value != 0)
            {
                GetComponent<AudioSource>().clip = walk;
                sound.SetFloat("PlayerVolume", soundVolume.value * 40 - 20);
            }
            isSprint = false;
            speed /= 2f;
            red.GetComponent<AreaCheck>().playerState = 1;
        }

        if(Input.GetKey(forward) || Input.GetKey(left) || Input.GetKey(behind) || Input.GetKey(right) && !walking && !loop)
        {
            if (!kid.GetComponent<LightsOff>().enabled)
            {
                red.GetComponent<AreaCheck>().enabled = true;
            }
            walking = true;
            GetComponent<AudioSource>().loop = true;
            loop = true;
            GetComponent<AudioSource>().Play();
        }
        else if (!Input.GetKey(forward) && !Input.GetKey(left) && !Input.GetKey(behind) && !Input.GetKey(right) && walking && loop)
        {
            if (!kid.GetComponent<LightsOff>().enabled)
            {
                red.GetComponent<AreaCheck>().enabled = false;
            }
            walking = false;
            GetComponent<AudioSource>().loop = false;
            GetComponent<AudioSource>().Stop();
            loop = false;
        }

        //Movements
        translation = Input.GetAxis("Vertical") * speed;
        straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);
    }
}
