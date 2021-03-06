﻿using UnityEngine;

/// <summary>
/// Script that will change the next teleportation's position of the Kid depending of the Player's current location
/// </summary>
public class ChangeSpawn : MonoBehaviour {

    //Objects
    public GameObject kid;

    //Variables
    private int timer;

	//Use this for initialization
	void Start () {
        kid = GameObject.FindWithTag("Kid");
	}

    /// <summary>
    /// Method that activate when the Player enter the collider of the object and analyse the name of the object it's assigned to to analyse the position of the Player
    /// </summary>
    /// <param name="other">Collider that enter this collider's area</param>
    private void OnTriggerEnter(Collider other)
    {
        //Check if the other collider is the Player
        if(other.tag == "Player")
        {
            ChangePos(name);
        }
    }

    /// <summary>
    /// Method that active when the player stay in the collition of the object and analyse the name of the object it's assigned to to check the position of the Player
    /// </summary>
    /// <param name="other">>Collider that enter this collider's area</param>
    private void OnTriggerStay(Collider other)
    {
        //Check if half of a second passed
        if (timer * Time.deltaTime > 0.5)
        {
            timer = 0;
            //Check if the other collider is the Player
            if (other.tag == "Player")
            {
                //Check the name of the GameObject to analyse the position of the player
                switch (name)
                {
                    case "Sa":
                        {
                            if (kid.GetComponent<Spawn>().x != -11.93f)
                            {
                                ChangePos(name);
                            }
                            break;
                        }
                    case "Ki":
                        {
                            if (kid.GetComponent<Spawn>().x != -0.88f)
                            {
                                ChangePos(name);
                            }
                            break;
                        }
                    case "C1":
                        {
                            if (kid.GetComponent<Spawn>().x != 23.7f)
                            {
                                ChangePos(name);
                            }
                            break;
                        }
                    case "Ca":
                        {
                            if (kid.GetComponent<Spawn>().x != -3.27f)
                            {
                                ChangePos(name);
                            }
                            break;
                        }
                    case "C2":
                        {
                            if (kid.GetComponent<Spawn>().x != 14.81f)
                            {
                                ChangePos(name);
                            }
                            break;
                        }
                    case "Ch":
                        {
                            if (kid.GetComponent<Spawn>().x != -7.59f)
                            {
                                ChangePos(name);
                            }
                            break;
                        }
                    case "Ot":
                        {
                            if (kid.GetComponent<Spawn>().x != 13.86f)
                            {
                                ChangePos(name);
                            }
                            break;
                        }
                    default:
                        {
                            if (kid.GetComponent<Spawn>().x != 18f)
                            {
                                ChangePos(name);
                            }
                            break;
                        }
                }
            }
        }
        else
        {
            ++timer;
        }
    }

    /// <summary>
    /// Method which change the teleportation's location of the kid
    /// </summary>
    /// <param name="name"></param>
    private void ChangePos(string name)
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
