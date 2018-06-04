using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToOptions : MonoBehaviour
{
    public GameObject panBase;
    public GameObject panOpti;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        panBase = GameObject.FindWithTag("PanelBase");
        panOpti = GameObject.FindWithTag("PanelOptions");
        player = GameObject.FindWithTag("Player");
    }
}
