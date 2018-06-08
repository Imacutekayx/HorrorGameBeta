using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCollision : MonoBehaviour {
    public GameObject red;

    private void Start()
    {
        red = GameObject.FindWithTag("RedEyes");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().tag == "Player")
        {
            red.GetComponent<AreaCheck>().isInArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Player")
        {
            red.GetComponent<AreaCheck>().isInArea = false;
        }
    }
}
