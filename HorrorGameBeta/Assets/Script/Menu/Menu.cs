using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    private int sizeEnter = 40;
    private int sizeExit = 35;
    public Material enter;
    public Material exit;

    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material = enter;
        GetComponent<UnityEngine.UI.Text>().fontSize = sizeEnter;
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material = exit;
        GetComponent<UnityEngine.UI.Text>().fontSize = sizeExit;
    }
}
