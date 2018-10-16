using UnityEngine;

/// <summary>
/// Script that analyse when the Player is in the area
/// </summary>
public class AreaCollision : MonoBehaviour {

    //Objects
    public GameObject red;

    //Use this for initialization
    private void Start()
    {
        red = GameObject.FindWithTag("RedEyes");
    }

    /// <summary>
    /// Method that check the collider that enters it
    /// </summary>
    /// <param name="other">The collider who enters this one</param>
    private void OnTriggerEnter(Collider other)
    {
        //Check if the collider is the Player
        if(other.GetComponent<Collider>().tag == "Player")
        {
            red.GetComponent<AreaCheck>().isInArea = true;
        }
    }

    /// <summary>
    /// Method that check the collider that exits it
    /// </summary>
    /// <param name="other">The collider who exits this one</param>
    private void OnTriggerExit(Collider other)
    {
        //Check if the collider is the Player
        if (other.GetComponent<Collider>().tag == "Player")
        {
            red.GetComponent<AreaCheck>().isInArea = false;
        }
    }
}
