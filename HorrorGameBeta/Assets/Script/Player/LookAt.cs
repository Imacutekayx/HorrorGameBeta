using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject kid;
    public GameObject red;
    private Vector3 hostPos;
    private Vector3 targetPos;
    private RaycastHit hit;

    // Use this for initialization
    void Start()
    {
        kid = GameObject.FindWithTag("Kid");
        red = GameObject.FindWithTag("RedEyes");
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.GetComponent<Collider>().tag)
        {
            case "Kid":
                {
                    kid.GetComponent<CheckSee>().isLookedAt = true;
                    break;
                }
            case "RedEyes":
                {
                    if (!red.GetComponent<Chase>().enabled && !kid.GetComponent<LightsOff>().enabled)
                    {
                        red.GetComponent<Chase>().enabled = true;
                        red.GetComponent<AreaCheck>().enabled = true;
                    }
                    break;
                }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Kid")
        {
            kid.GetComponent<CheckSee>().isLookedAt = false;
        }
    }
}
