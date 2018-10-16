using UnityEngine;

/// <summary>
/// Script that check if the Player looks at the Kid
/// </summary>
public class LookAt : MonoBehaviour
{

    //Objects
    public GameObject kid;
    public GameObject red;
    private Vector3 hostPos;
    private Vector3 targetPos;
    private RaycastHit hit;

    //Use this for initialization
    void Start()
    {
        kid = GameObject.FindWithTag("Kid");
        red = GameObject.FindWithTag("RedEyes");
    }

    /// <summary>
    /// Method that check the collider that enters it
    /// </summary>
    /// <param name="other">The collider who enters this one</param>
    private void OnTriggerEnter(Collider other)
    {
        //CHeck which collider entered
        switch (other.GetComponent<Collider>().tag)
        {
            case "Kid":
                {
                    kid.GetComponent<CheckSee>().isLookedAt = true;
                    break;
                }
            case "RedEyes":
                {
                    //Check if the component Chase of the RedEyes is enabled
                    if (!red.GetComponent<Chase>().enabled && !kid.GetComponent<LightsOff>().enabled)
                    {
                        red.GetComponent<Chase>().enabled = true;
                        red.GetComponent<AreaCheck>().enabled = true;
                    }
                    break;
                }
        }
    }

    /// <summary>
    /// Method that check the collider that exits it
    /// </summary>
    /// <param name="other">The collider who exits this one</param>
    private void OnTriggerExit(Collider other)
    {
        //Check if the colllider is Kid
        if (other.GetComponent<Collider>().tag == "Kid")
        {
            kid.GetComponent<CheckSee>().isLookedAt = false;
        }
    }
}
