using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script that will play a sound when the mouse is on the buttons or are clicked
/// </summary>
public class OnEnter : MonoBehaviour {

    //Objects
    public GameObject menu;
    public AudioClip onMenu;
    public AudioClip click;
    public Material basic;
    public Material on;
    private AudioSource audioSource;

    //Variables
    private bool inside = false;
    private bool isClicking = false;

    //Use this for initialization
    private void Start()
    {
        menu = GameObject.FindWithTag("Menu");
        audioSource = menu.GetComponent<AudioSource>();
    }

    //Active when the mouse enter the object's area
    private void OnMouseEnter()
    {
        transform.GetChild(0).GetComponent<Text>().material = on;
        audioSource.clip = onMenu;
        audioSource.Play();
        inside = true;
        Debug.Log("In");
    }

    //Active when the mouse exit the object's area
    private void OnMouseExit()
    {
        transform.GetChild(0).GetComponent<Text>().material = basic;
        inside = false;
        Debug.Log("Out");
    }

    //Update is called once per frame
    private void Update()
    {
        //Check if the mouse is inside the area
        if (inside)
        {
            //Check if the User click
            if (Input.GetMouseButtonDown(0) && !isClicking)
            {
                isClicking = true;
                audioSource.clip = click;
                audioSource.Play();
            }
            else if (isClicking)
            {
                isClicking = false;
            }
        }
    }
}
