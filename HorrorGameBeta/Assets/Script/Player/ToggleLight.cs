﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour {
    public Light spot;

	// Use this for initialization
	void Start () {
        spot = GetComponent<Light>();
        spot.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("f"))
        {
            if(spot.enabled == true)
            {
                spot.enabled = false;
            }
            else
            {
                spot.enabled = true;
            }
        }
	}
}