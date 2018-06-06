using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    public GameObject target;
    public GameObject red;
    public GameObject kid;
    public GameObject house;
    public Material green;
    public AudioClip bouton;
    public AudioClip lightOn;
    private Renderer rend;
    private GameObject[] lights;

    public int maxRange;
    public int minRange;


    // Use this for initialization
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        red = GameObject.FindWithTag("RedEyes");
        kid = GameObject.FindWithTag("Kid");
        house = GameObject.FindWithTag("Environnement");
        lights = GameObject.FindGameObjectsWithTag("Light");
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector3.Distance(transform.position, target.transform.position) < maxRange)
           && (Vector3.Distance(transform.position, target.transform.position) > minRange))
        {
            if (Input.GetKey("e"))
            {
                GetComponent<AudioSource>().clip = bouton;
                GetComponent<AudioSource>().Play();

                red.GetComponent<Pathfinding>().enabled = false;
                red.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                red.transform.position = new Vector3(18.72f, 16.38f, -29.36f);
                
                house.GetComponent<AudioSource>().clip = lightOn;
                house.GetComponent<AudioSource>().Play();

                foreach (GameObject li in lights)
                {
                    li.GetComponent<Light>().enabled = true;
                }

                rend.material = green;

                kid.GetComponent<LightsOff>().on = true;
                kid.GetComponent<LightsOff>().timer = 0;
                GetComponent<Switch>().enabled = false;
            }
        }
    }
}
