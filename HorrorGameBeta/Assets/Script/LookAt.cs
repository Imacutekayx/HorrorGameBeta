using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject kid;
    private Vector3 hostPos;
    private Vector3 targetPos;
    private RaycastHit hit;

    private float distance = 10f * Mathf.Pow(10, 10);

    // Use this for initialization
    void Start()
    {
        kid = GameObject.FindWithTag("Kid");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToTarget = transform.position - kid.transform.position;
        float angle = Vector3.Angle(transform.forward, directionToTarget);
        float distance = directionToTarget.magnitude;

        if (Mathf.Abs(angle) < 45 && distance < 10 * Mathf.Pow(10, 10))
        {
            kid.GetComponent<CheckSee>().isLookedAt = true;
        }
        else
        {
            kid.GetComponent<CheckSee>().isLookedAt = false;
        }
    }
}
