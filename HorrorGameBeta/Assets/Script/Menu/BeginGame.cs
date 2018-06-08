using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginGame : MonoBehaviour {
    public GameObject panelMyuuji;
    public GameObject panelBase;
    public GameObject musicPlayer;
	
	// Update is called once per frame
	public void Begin () {
        panelMyuuji.SetActive(false);
        panelBase.SetActive(true);
        musicPlayer.GetComponent<AudioSource>().Play();
        GetComponent<BeginGame>().enabled = false;
	}
}
