using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 2;
    public float turn = 2;
    private float turning;
	
	// Update is called once per frame
	public void Update () {
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
