using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Experimental.UIElements;

/// <summary>
/// Script that will move the player underwater
/// </summary>
public class UWMovement : MonoBehaviour{

    //Objects
    public AudioMixer sound;
    public AudioClip swim;
    public AudioClip rush;
    public Slider soundVolume;

    //Variables
    public KeyCode forward;
    public KeyCode behind;
    public KeyCode left;
    public KeyCode right;
    public KeyCode sprint;
    public KeyCode forwardBtn;
    public KeyCode behindBtn;
    public KeyCode leftBtn;
    public KeyCode rightBtn;
    public KeyCode sprintBtn;
    public float speed;
    public int o2Remaining = 100;
    private bool isRush = false;
    private bool isSwim = true;
    private bool isMoving = false;

    //TODO Import controller movements
    //Update is called once per frame
    void Update () {

        //TODO Fix sound bug
        //Check of the rushing mode
		if((Input.GetKey(sprint)) && isSwim && o2Remaining > 0)
        {
            isSwim = false;
            isRush = true;
            GetComponent<O2>().speed = 0.5f;
            speed *= 2;
            //GetComponent<AudioSource>().clip = rush;
            //GetComponent<AudioSource>().Play();
        }
        else if((!Input.GetKey(sprint)) && isRush)
        {
            isRush = false;
            isSwim = true;
            GetComponent<O2>().speed = 1;
            speed /= 2;
            //GetComponent<AudioSource>().clip = swim;
            //GetComponent<AudioSource>().Play();
        }

        //Check if moving
        if((Input.GetKey(forward) || Input.GetKey(left) || Input.GetKey(right) || Input.GetKey(behind)) && !isMoving)
        {
            GetComponent<AudioSource>().loop = true;
            //GetComponent<AudioSource>().Play();
        }
        else if ((!Input.GetKey(forward) && !Input.GetKey(left) && !Input.GetKey(right) && !Input.GetKey(behind)) && isMoving)
        {
            GetComponent<AudioSource>().loop = false;
        }

        //Basic movements
        if (Input.GetKey(forward))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(left))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(right))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(behind))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }
}
