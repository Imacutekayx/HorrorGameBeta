using UnityEngine;

/// <summary>
/// Script that will change the next teleportation's position of the Kid depending of the Player's current location
/// </summary>
public class ChangeSpawn : MonoBehaviour {

    //Objects
    public GameObject kid;

	//Use this for initialization
	void Start () {
        kid = GameObject.FindWithTag("Kid");
	}

    /// <summary>
    /// Method that activate when the Player enter the collider of the object and analyse the name of the object it's assign to to analyse the position of the Player
    /// </summary>
    /// <param name="other">Collider that enter the this collider's area</param>
    private void OnTriggerEnter(Collider other)
    {
        //Check if the other collider is the Player
        if(other.tag == "Player")
        {
            //Check the name of the GameObject to change the Kid's teleportation's position
            switch (name)
            {
                case "Sa":
                    {
                        kid.GetComponent<Spawn>().x = -11.93f;
                        kid.GetComponent<Spawn>().y = 2.79f;
                        kid.GetComponent<Spawn>().z = -21.84f;
                        break;
                    }
                case "Ki":
                    {
                        kid.GetComponent<Spawn>().x = -0.88f;
                        kid.GetComponent<Spawn>().y = 4.1f;
                        kid.GetComponent<Spawn>().z = 22.42f;
                        break;
                    }
                case "C1":
                    {
                        kid.GetComponent<Spawn>().x = 23.7f;
                        kid.GetComponent<Spawn>().y = 2.79f;
                        kid.GetComponent<Spawn>().z = 16.1f;
                        break;
                    }
                case "Ca":
                    {
                        kid.GetComponent<Spawn>().x = -3.27f;
                        kid.GetComponent<Spawn>().y = -6.53f;
                        kid.GetComponent<Spawn>().z = 22.15f;
                        break;
                    }
                case "C2":
                    {
                        kid.GetComponent<Spawn>().x = 14.81f;
                        kid.GetComponent<Spawn>().y = 13.82f;
                        kid.GetComponent<Spawn>().z = 20.94f;
                        break;
                    }
                case "Ch":
                    {
                        kid.GetComponent<Spawn>().x = -7.59f;
                        kid.GetComponent<Spawn>().y = 13.82f;
                        kid.GetComponent<Spawn>().z = 3.59f;
                        break;
                    }
                case "Ot":
                    {
                        kid.GetComponent<Spawn>().x = 13.86f;
                        kid.GetComponent<Spawn>().y = 13.82f;
                        kid.GetComponent<Spawn>().z = -20.13f;
                        break;
                    }
                default:
                    {
                        kid.GetComponent<Spawn>().x = 18f;
                        kid.GetComponent<Spawn>().y = 30f;
                        kid.GetComponent<Spawn>().z = -28f;
                        break;
                    }
            }
        }
    }
}
