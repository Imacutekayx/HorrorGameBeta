using UnityEngine;

/// <summary>
/// Script that will shut down the lights and active the RedEyes
/// </summary>
public class LightsOff : MonoBehaviour {

    //Objects
    private GameObject[] lights;
    public GameObject kid;
    public GameObject red;
    public GameObject house;
    public GameObject musicPlayer;
    public GameObject battery;
    public Material redLight;
    public AudioClip powerOff;
    public AudioClip spawnRed;
    public AudioClip lightOff;

    //Variables
    public int timer = 0;
    public bool on = true;
    private float floatX;
    private byte rnd;
    private byte rnd2;

    //Use this for initialization
    void Start ()
    {
        lights = GameObject.FindGameObjectsWithTag("Light");
        kid = GameObject.FindWithTag("Kid");
        red = GameObject.FindWithTag("RedEyes");
        house = GameObject.FindWithTag("Environnement");
        musicPlayer = GameObject.FindWithTag("Music");
    }

    //Update is called once per frame
    private void Update()
    {
        //Check if the timer is higher than 60 seconds
        if(timer*Time.deltaTime > 60 && on)
        {
            on = false;

            //Shut down the lights
            foreach (GameObject li in lights)
            {
                li.GetComponent<Light>().enabled = false;
            }
            
            //Random a floor other than the one where the Player is and teleport the RedEyes there
            rnd = System.Convert.ToByte(Random.Range(0, 2));
            rnd2 = System.Convert.ToByte(Random.Range(0, 2));
            floatX = kid.GetComponent<Spawn>().x;
            System.Console.WriteLine(floatX);
            //Check if the Player is somewhere in the game
            if (floatX != 18)
            {
                //Check if the Player is at the floor 0
                if(floatX == -3.27f)
                {
                    //Check the Random to choose the floor to reach
                    if(rnd == 0)
                    {
                        GameObject.FindWithTag("S1").GetComponent<Renderer>().material = redLight;
                        GameObject.FindWithTag("S1").GetComponent<Switch>().enabled = true;
                        red.transform.SetPositionAndRotation(new Vector3(18.72f, 5.34f, -29.36f), Quaternion.Euler(0, 0, 0));
                        //Check the Random to choose the position of the battery
                        if(rnd2 == 0)
                        {
                            battery.transform.SetPositionAndRotation(new Vector3(-20.74f, 13.428f, -7.8f), Quaternion.Euler(90, 40, 0));
                        }
                        else
                        {
                            battery.transform.SetPositionAndRotation(new Vector3(9.87f, 11.63f, 8.67f), Quaternion.Euler(90, 70, 0));
                        }
                    }
                    else
                    {
                        GameObject.FindWithTag("S2").GetComponent<Renderer>().material = redLight;
                        GameObject.FindWithTag("S2").GetComponent<Switch>().enabled = true;
                        red.transform.SetPositionAndRotation(new Vector3(18.72f, 16.38f, -29.36f), Quaternion.Euler(0, 0, 0));
                        //Check the Random to choose the position of the battery
                        if (rnd2 == 0)
                        {
                            battery.transform.SetPositionAndRotation(new Vector3(-3.992f, 1.794f, -20.894f), Quaternion.Euler(90, 95, 0));
                        }
                        else
                        {
                            battery.transform.SetPositionAndRotation(new Vector3(8.63f, 3.553f, 22.9f), Quaternion.Euler(90, 30, 0));
                        }
                    }
                }
                //Check if the Player is at the floor 1
                else if (floatX == -11.93f || floatX == -0.88 || floatX == 23.7)
                {
                    //Check the Random to choose the floor to reach
                    if (rnd == 0)
                    {
                        GameObject.FindWithTag("S0").GetComponent<Renderer>().material = redLight;
                        GameObject.FindWithTag("S0").GetComponent<Switch>().enabled = true;
                        red.transform.SetPositionAndRotation(new Vector3(19.38f, -5.05f, 19.39f), Quaternion.Euler(0, 0, 0));
                        //Check the Random to choose the position of the battery
                        if (rnd2 == 0)
                        {
                            battery.transform.SetPositionAndRotation(new Vector3(-20.74f, 13.428f, -7.8f), Quaternion.Euler(90, 40, 0));
                        }
                        else
                        {
                            battery.transform.SetPositionAndRotation(new Vector3(9.87f, 11.63f, 8.67f), Quaternion.Euler(90, 70, 0));
                        }
                    }
                    else
                    {
                        GameObject.FindWithTag("S2").GetComponent<Renderer>().material = redLight;
                        GameObject.FindWithTag("S2").GetComponent<Switch>().enabled = true;
                        red.transform.SetPositionAndRotation(new Vector3(18.72f, 16.38f, -29.36f), Quaternion.Euler(0, 0, 0));
                        battery.transform.SetPositionAndRotation(new Vector3(21.348f, -8.57f, -10.339f), Quaternion.Euler(90, 15, 0));
                    }
                }
                //Check if the Player is at the floor 2
                else
                {
                    //Check the Random to choose the floor to reach
                    if (rnd == 0)
                    {
                        GameObject.FindWithTag("S0").GetComponent<Renderer>().material = redLight;
                        GameObject.FindWithTag("S0").GetComponent<Switch>().enabled = true;
                        red.transform.SetPositionAndRotation(new Vector3(19.38f, -5.05f, 19.39f), Quaternion.Euler(0, 0, 0));
                        //Check the Random to choose the position of the battery
                        if (rnd2 == 0)
                        {
                            battery.transform.SetPositionAndRotation(new Vector3(-3.992f, 1.794f, -20.894f), Quaternion.Euler(90, 95, 0));
                        }
                        else
                        {
                            battery.transform.SetPositionAndRotation(new Vector3(9.87f, 11.63f, 8.67f), Quaternion.Euler(90, 70, 0));
                        }
                    }
                    else
                    {
                        GameObject.FindWithTag("S1").GetComponent<Renderer>().material = redLight;
                        GameObject.FindWithTag("S1").GetComponent<Switch>().enabled = true;
                        red.transform.SetPositionAndRotation(new Vector3(18.72f, 5.34f, -29.36f), Quaternion.Euler(0, 0, 0));
                        battery.transform.SetPositionAndRotation(new Vector3(21.348f, -8.57f, -10.339f), Quaternion.Euler(90, 15, 0));
                    }
                }
            }
            //Enable RedEyes's Components and change the ambiance
            red.GetComponent<AudioSource>().clip = spawnRed;
            red.GetComponent<AudioSource>().Play();
            red.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
            red.GetComponent<Pathfinding>().enabled = true;
            house.GetComponent<AudioSource>().clip = powerOff;
            house.GetComponent<AudioSource>().Play();
            kid.GetComponent<LightsOff>().enabled = false;
            musicPlayer.GetComponent<AudioSource>().clip = lightOff;
            musicPlayer.GetComponent<AudioSource>().Play();
        }
        else
        {
            ++timer;
        }
    }
}
