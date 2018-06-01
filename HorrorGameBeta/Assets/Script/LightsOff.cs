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

            rnd = System.Convert.ToByte(Random.Range(0, 2));
            floatX = kid.GetComponent<Spawn>().x;
            if (floatX != 18)
            {
                //0
                if(floatX == -3.27f)
                {
                    if(rnd == 0)
                    {
                        GameObject.FindWithTag("S1").GetComponent<Renderer>().material = redLight;
                        GameObject.FindWithTag("S1").GetComponent<Switch>().enabled = true;
                    }
                    else
                    {
                        GameObject.FindWithTag("S2").GetComponent<Renderer>().material = redLight;
                        GameObject.FindWithTag("S2").GetComponent<Switch>().enabled = true;
                    }
                }
                //1
                else if(floatX == -11.93f || floatX == -0.88 || floatX == 23.7)
                {
                    if(rnd == 0)
                    {
                        GameObject.FindWithTag("S0").GetComponent<Renderer>().material = redLight;
                        GameObject.FindWithTag("S0").GetComponent<Switch>().enabled = true;
                    }
                    else
                    {
                        GameObject.FindWithTag("S2").GetComponent<Renderer>().material = redLight;
                        GameObject.FindWithTag("S2").GetComponent<Switch>().enabled = true;

                    }
                }
                //2
                else
                {
                    if(rnd == 0)
                    {
                        GameObject.FindWithTag("S0").GetComponent<Renderer>().material = redLight;
                        GameObject.FindWithTag("S0").GetComponent<Switch>().enabled = true;
                    }
                    else
                    {
                        GameObject.FindWithTag("S1").GetComponent<Renderer>().material = redLight;
                        GameObject.FindWithTag("S1").GetComponent<Switch>().enabled = true;
                    }
                }
            }
            red.GetComponent<Pathfinding>().enabled = true;
        }
        else
        {
            ++timer;
        }
    }
}
