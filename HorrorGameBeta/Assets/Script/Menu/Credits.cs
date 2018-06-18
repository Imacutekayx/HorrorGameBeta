using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour {

    //Objects
    public GameObject pnlTBC;
    public GameObject pnlDev;
    public GameObject pnlMus;
    public GameObject pnlThx;

    //Variables
    private int timer;

    //Update is called once per frame
    void Update () {
        if(timer*Time.deltaTime > 9)
        {
            pnlMus.SetActive(false);
            pnlThx.SetActive(true);
        }
        else if(timer*Time.deltaTime > 6)
        {
            pnlDev.SetActive(false);
            pnlMus.SetActive(true);
        }
        else if(timer*Time.deltaTime > 3)
        {
            pnlTBC.SetActive(false);
            pnlDev.SetActive(true);
        }
        else
        {
            ++timer;
        }
	}
}
