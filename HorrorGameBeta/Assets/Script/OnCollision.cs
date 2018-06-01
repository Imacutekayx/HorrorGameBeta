using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour {

    public GameObject cam;

	// Use this for initialization
	void Start () {
        cam = GameObject.FindWithTag("MainCamera");
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            cam.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
        }
    }
}
