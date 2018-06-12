using UnityEngine;

/// <summary>
/// Script that toggle the PLayerLight on and off
/// </summary>
public class ToggleLight : MonoBehaviour {

    //Objects
    public Light spot;

    //Variables
    public KeyCode key;

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
            else
            {
                spot.enabled = true;
            }
        }
	}
}
