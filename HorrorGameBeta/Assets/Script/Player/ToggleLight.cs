using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script that toggle the PLayerLight on and off
/// </summary>
public class ToggleLight : MonoBehaviour {

    //Objects
    public Light spot;
    public Slider batteryBar;

    //Variables
    public KeyCode key;
    public KeyCode button;
    public float timer;
    public float generalTimer;
    public int batteryTime = 100;

	//Use this for initialization
	void Start () {
        spot = GetComponent<Light>();
        spot.enabled = false;
	}
	
	//Update is called once per frame
	void Update () {
        //Check if the User press the LightKey
        if (Input.GetKeyDown(key) || Input.GetKeyDown(button))
        {
            //Check the state of the PlayerLight before changing it
            if(spot.enabled == true)
            {
                spot.enabled = false;
            }
            else if(batteryTime != 0)
            {
                spot.enabled = true;
            }
        }
        //Check if the PlayerLight is enabled
        if (spot.enabled)
        {
            //Calculate the battery remaining
            ++timer;
            batteryTime = Convert.ToInt32(100 - (timer * Time.deltaTime * 2));
            //Check if the battery is empty
            if(batteryTime == 0)
            {
                spot.enabled = false;
            }
            if(batteryBar.value != batteryTime)
            {
                batteryBar.value = batteryTime;
            }
        }
	}
}
