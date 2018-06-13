using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script that toggle the PLayerLight on and off
/// </summary>
public class ToggleLight : MonoBehaviour {

    //Objects
    public Light spot;
    public Image batteryBar;    

    //Variables
    public KeyCode key;
    public float timer;
    public int batteryTime = 100;

	//Use this for initialization
	void Start () {
        spot = GetComponent<Light>();
        spot.enabled = false;
	}
	
	//Update is called once per frame
	void Update () {
        //Check if the User press the LightKey
        if (Input.GetKeyDown(key))
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
            batteryTime = Convert.ToInt32(100 - (timer * Time.deltaTime * 3));
            //Check if the battery is empty
            if(batteryTime == 0)
            {
                spot.enabled = false;
            } 
            //TODO BatteryBar
        }
	}
}
