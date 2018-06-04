using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSee : MonoBehaviour {
    public GameObject player;
    public GameObject playerLight;
    public GameObject kid;
    private Light spot;

    public bool isLookedAt = false;
    public float killCount;
    public float safeCount;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        playerLight = GameObject.FindWithTag("PlayerLight");
        spot = playerLight.GetComponent<Light>();
        killCount = 0;
        safeCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(player.transform);

        if (isLookedAt && spot.enabled == true)
        {
            ++safeCount;
            if(safeCount * Time.deltaTime > 5)
            {
                transform.SetPositionAndRotation(new Vector3(18f, 30f, -28f), Quaternion.Euler(0, 0, 0));
                GetComponent<Spawn>().timer = 0;
                GetComponent<Spawn>().enabled = true;
                GetComponent<CheckSee>().enabled = false;
            }
        }
        else
        {
            ++killCount;
            if(killCount * Time.deltaTime > 3)
            {
                player.transform.LookAt(new Vector3(0, 9000, 0));
                //TODO Play KillKid
                player.GetComponent<Movement>().enabled = false;
                player.GetComponent<Rotation>().enabled = false;
                GetComponent<CheckSee>().enabled = false;
            }
        }
    }
}
