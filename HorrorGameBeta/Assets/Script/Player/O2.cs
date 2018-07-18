using UnityEngine;

//Script that manage the O2 of the player
public class O2 : MonoBehaviour {

    //Variables
    public float speed = 1;
    private float timer = 0;
	
	//Update is called once per frame
	void Update () {
		if(++timer * Time.deltaTime > speed)
        {
            timer = 0;
            --GetComponent<UWMovement>().o2Remaining;
            if(GetComponent<UWMovement>().o2Remaining == 0)
            {
                //TODO GameOver
            }
        }
	}
}
