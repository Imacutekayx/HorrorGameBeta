using UnityEngine;

/// <summary>
/// Script that will teleport the Kid at the Player's location
/// </summary>
public class Spawn : MonoBehaviour {

    //Objects
    public AudioClip laugh;

    //Variables
    public float x = 18;
    public float y = 30;
    public float z = -28;
    public int timer = 0;

    //Use this for initialization
    private void Start()
    {
        timer = 0;
    }

    //Update is called once per frame
    private void Update()
    {
        //Check if the timer is more than 30 seconds and teleport the Kid to the Player
        if(timer*Time.deltaTime > 20)
        {
            transform.SetPositionAndRotation(new Vector3(x, y, z), Quaternion.Euler(0,0,0));
            GetComponent<CheckSee>().killCount = 0;
            GetComponent<CheckSee>().safeCount = 0;
            GetComponent<CheckSee>().enabled = true;
            GetComponent<AudioSource>().clip = laugh;
            GetComponent<AudioSource>().Play();
            GetComponent<Spawn>().enabled = false;
        }
        else
        {
            ++timer;
        }
    }
}
