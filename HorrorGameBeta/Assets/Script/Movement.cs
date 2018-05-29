using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 0.2f;
    public float turn = 2f;
    private float turning;
    private bool down;
	
	// Update is called once per frame
	public void Update () {
        //if (Input.GetKeyDown("left ctrl"))
        //{
        //    transform.position -= transform.up * speed;
        //}
        //else if(Input.GetKeyDown("left shift"))
        //{
        //    speed = speed * 1.5f;
        //}
        //else
        //{
        //    speed = speed / 1.5f;
        //}
        if (Input.GetKey("w"))
        {
            transform.position += transform.forward * speed;
        }
        if (Input.GetKey("a"))
        {
            transform.position -= transform.right * speed;
        }
        if (Input.GetKey("s"))
        {
            transform.position -= transform.forward * speed;
        }
        if (Input.GetKey("d"))
        {
            transform.position += transform.right * speed;
        }
        turning = turn * Input.GetAxis("Mouse X");
        transform.Rotate(0, turning, 0);
    }
}
