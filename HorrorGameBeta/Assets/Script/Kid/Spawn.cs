using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Spawn : MonoBehaviour {
    public float x = 18;
    public float y = 30;
    public float z = -28;
    public int timer = 0;

    public AudioClip laugh;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        if(timer*Time.deltaTime > 30)
        {
            transform.SetPositionAndRotation(new Vector3(x, y, z), Quaternion.Euler(0,0,0));
            GetComponent<CheckSee>().killCount = 0;
            GetComponent<CheckSee>().safeCount = 0;
            GetComponent<CheckSee>().enabled = true;
            GetComponent<AudioSource>().clip = laugh;
            GetComponent<AudioSource>().Play();
            GetComponent<Spawn>().enabled = false;
        }
        else
        {
            ++timer;
        }
    }
}
