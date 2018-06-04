using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOff : MonoBehaviour {

    public int timer = 0;
    public bool on = true;
    private float floatX;
    private byte rnd;
    
    private GameObject[] lights;
    public GameObject kid;
    public GameObject red;
    public Material redLight;

    // Use this for initialization
    void Start ()
    {
        lights = GameObject.FindGameObjectsWithTag("Light");
        kid = GameObject.FindWithTag("Kid");
        red = GameObject.FindWithTag("RedEyes");
    }

    private void Update()
    {
        if(timer*Time.deltaTime > 60 && on)
        {
            on = false;

            foreach (GameObject li in lights)
            {
                li.GetComponent<Light>().enabled = false;
            }

            //TODO Play PowerOff
            rnd = System.Convert.ToByte(Random.Range(0, 2));
            floatX = kid.GetComponent<Spawn>().x;
            System.Console.WriteLine(floatX);
            if (floatX != 18)
            {
                //0
                if(floatX == -3.27f)
                {
                    if(rnd == 0)
                    {
                        GameObject.FindWithTag("S1").GetComponent<Renderer>().material = redLight;
                        GameObject.FindWithTag("S1").GetComponent<Switch>().enabled = true;
                        red.transform.SetPositionAndRotation(new Vector3(18.72f, 5.34f, -29.36f), Quaternion.Euler(0, 0, 0));
                    }
                    else
                    {
                        GameObject.FindWithTag("S2").GetComponent<Renderer>().material = redLight;
                        GameObject.FindWithTag("S2").GetComponent<Switch>().enabled = true;
                        red.transform.SetPositionAndRotation(new Vector3(18.72f, 16.38f, -29.36f), Quaternion.Euler(0, 0, 0));
                    }
                }
                //1
                else if(floatX == -11.93f || floatX == -0.88 || floatX == 23.7)
                {
                    if(rnd == 0)
                    {
                        GameObject.FindWithTag("S0").GetComponent<Renderer>().material = redLight;
                        GameObject.FindWithTag("S0").GetComponent<Switch>().enabled = true;
                        red.transform.SetPositionAndRotation(new Vector3(19.38f, -5.05f, 19.39f), Quaternion.Euler(0, 0, 0));
                    }
                    else
                    {
                        GameObject.FindWithTag("S2").GetComponent<Renderer>().material = redLight;
                        GameObject.FindWithTag("S2").GetComponent<Switch>().enabled = true;
                        red.transform.SetPositionAndRotation(new Vector3(18.72f, 16.38f, -29.36f), Quaternion.Euler(0, 0, 0));
                    }
                }
                //2
                else
                {
                    if(rnd == 0)
                    {
                        GameObject.FindWithTag("S0").GetComponent<Renderer>().material = redLight;
                        GameObject.FindWithTag("S0").GetComponent<Switch>().enabled = true;
                        red.transform.SetPositionAndRotation(new Vector3(19.38f, -5.05f, 19.39f), Quaternion.Euler(0, 0, 0));
                    }
                    else
                    {
                        GameObject.FindWithTag("S1").GetComponent<Renderer>().material = redLight;
                        GameObject.FindWithTag("S1").GetComponent<Switch>().enabled = true;
                        red.transform.SetPositionAndRotation(new Vector3(18.72f, 5.34f, -29.36f), Quaternion.Euler(0, 0, 0));
                    }
                }
            }
            red.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
            red.GetComponent<Pathfinding>().enabled = true;
            //TODO Play LightOff
            kid.GetComponent<LightsOff>().enabled = false;
        }
        else
        {
            ++timer;
        }
    }
}
