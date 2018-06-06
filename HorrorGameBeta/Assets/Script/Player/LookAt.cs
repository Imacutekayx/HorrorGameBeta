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
        //TODO LookAt who change isLookedAt value of CheckSee
    }
}
