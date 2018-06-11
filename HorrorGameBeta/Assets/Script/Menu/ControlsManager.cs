using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsManager : MonoBehaviour{
    public GameObject player;
    public GameObject playerLight;
    public GameObject s0;
    public GameObject s1;
    public GameObject s2;

    private Controls controls;

	// Use this for initialization
	public void StartAssign () {
        player = GameObject.FindWithTag("Player");
        playerLight = GameObject.FindWithTag("PlayerLight");
        s0 = GameObject.FindWithTag("S0");
        s1 = GameObject.FindWithTag("S1");
        s2 = GameObject.FindWithTag("S2");
        controls = Controls.LoadFromFile(Application.dataPath + "/Save/controls.xml");
        
        player.GetComponent<Movement>().forward = controls.lstKeys[0].keyValue;
        player.GetComponent<Movement>().behind = controls.lstKeys[1].keyValue;
        player.GetComponent<Movement>().left = controls.lstKeys[2].keyValue;
        player.GetComponent<Movement>().right = controls.lstKeys[3].keyValue;
        player.GetComponent<Movement>().crouch = controls.lstKeys[4].keyValue;
        player.GetComponent<Movement>().sprint = controls.lstKeys[5].keyValue;
        player.GetComponent<Escape>().key = controls.lstKeys[8].keyValue;
        playerLight.GetComponent<ToggleLight>().key = controls.lstKeys[7].keyValue;
        s0.GetComponent<Switch>().interact = controls.lstKeys[6].keyValue;
        Debug.Log("ControlsManager true");
    }
	
	public void ChargeKeys()
    {
        controls = Controls.LoadFromFile(Application.dataPath + "/Save/controls.xml");
    }

    public void ChangeKey(string name, string value)
    {
        controls = Controls.LoadFromFile(Application.dataPath + "/Save/controls.xml");
        foreach(Keys key in controls.lstKeys)
        {
            if(key.keyName == name)
            {
                key.keyValue = value;
            }
        }
        controls.Save(Application.dataPath + "/Save/controls.xml");
    }
}
