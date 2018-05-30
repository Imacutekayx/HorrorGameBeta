using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 2.5f;
    private float translation;
    private float straffe;
    private bool croutch = false;
    private bool sprint = false;
    private bool allowSprint = true;

    private CapsuleCollider coll;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    public void Update ()
    {
        //Croutch
        if (Input.GetKey("left ctrl"))
        {
            croutch = true;
            allowSprint = false;
            coll = GetComponent<CapsuleCollider>();
            coll.height = 1.5f;
            transform.Translate(0, -0.1f, 0);

        }
        else if (croutch)
        {
            croutch = false;
            allowSprint = true;
            coll = GetComponent<CapsuleCollider>();
            transform.Translate(0, 2.5f, 0);
            coll.height = 5f;
        }

        //Sprint
        if(Input.GetKey("left shift") && allowSprint)
        {
            sprint = true;
            speed *= 1.1f;
        }
        else if (sprint)
        {
            sprint = false;
            speed /= 1.1f;
        }

        //Movements
        translation = Input.GetAxis("Vertical") * speed;
        straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);
    }
}
