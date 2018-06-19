using UnityEngine;

/// <summary>
/// Script that show the credits
/// </summary>
public class Credits : MonoBehaviour {

    //Objects
    public GameObject pnlTBC;
    public GameObject pnlDev;
    public GameObject pnlMus;
    public GameObject pnlSou;
    public GameObject pnlThx;
    
    //Variables
    public bool chkDev;
    public bool chkMus;
    public bool chkSou;
    public bool chkThx;
    public bool chkCur;
    public int timer;

    //Update is called once per frame
    void Update () {
        if(timer*Time.deltaTime > 23 && !chkCur)
        {
            chkCur = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if(timer*Time.deltaTime > 20 && !chkThx)
        {
            chkThx = true;
            pnlSou.SetActive(false);
            pnlThx.SetActive(true);
        }
        else if(timer*Time.deltaTime > 15 && !chkSou)
        {
            chkSou = true;
            pnlMus.SetActive(false);
            pnlSou.SetActive(true);
        }
        else if(timer*Time.deltaTime > 10 && !chkMus)
        {
            chkMus = true;
            pnlDev.SetActive(false);
            pnlMus.SetActive(true);
        }
        else if(timer*Time.deltaTime > 5 && !chkDev)
        {
            chkDev = true;
            pnlTBC.SetActive(false);
            pnlDev.SetActive(true);
        }
        else
        {
            ++timer;
        }
	}
}
