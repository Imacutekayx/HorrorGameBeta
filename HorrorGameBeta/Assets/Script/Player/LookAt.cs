using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject kid;
    private Vector3 hostPos;
    private Vector3 targetPos;
    private RaycastHit hit;

    // Use this for initialization
    void Start()
    {
        kid = GameObject.FindWithTag("Kid");
    }

    // Update is called once per frame
    void Update()
    {
        // Will contain the information of which object the raycast hit
        RaycastHit hit;

        // if raycast hits, it checks if it hit an object with the tag Player
        if (Physics.Raycast(transform.position, transform.forward, out hit, 10000) &&
                    hit.collider.gameObject.CompareTag("Kid"))
        {
            Debug.Log("True");
        }
        else
        {
            Debug.Log("false");
        }
    }
}
