using UnityEngine;

//Script which tell the Depth to chase the player and if the player is in a safeZone
public class RushPlayer : MonoBehaviour {

    //Objects
    public GameObject player;
    private GameObject[] safePoints;

    //Variables
    public float safeDistance;
    public int speed;
    private float timer;
    private bool isRushing = false;
    private bool isOut = false;
    private bool isSafe = false;
    private float x;
    private float y;
    private float z;
    private byte startLoc;

	//Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        safePoints = GameObject.FindGameObjectsWithTag("SafePoints");
	}
	
	//Update is called once per frame
	void Update () {
        //TODO Fix bug rotation && after limit
        //Check the state of Depth
        if (!isOut)
        {
            if (!isRushing)
            {
                //If the timer is over, start rushing the player
                if (++timer * Time.deltaTime > 5)
                {
                    timer = 0;
                    startLoc = (byte)Random.Range(0, 3);
                    isRushing = true;

                    //Teleport the Depth depending of the startLoc
                    switch (startLoc)
                    {
                        //Down
                        case 0:
                            {
                                transform.SetPositionAndRotation(player.transform.position + new Vector3(0, -2500, 0), Quaternion.Euler(0f, 0f, 0f));
                                break;
                            }
                        //Up
                        case 1:
                            {
                                transform.SetPositionAndRotation(player.transform.position + new Vector3(0, 2500, 0), Quaternion.Euler(180f, 0f, 0f));
                                break;
                            }
                        //Left
                        case 2:
                            {
                                transform.SetPositionAndRotation(player.transform.position + new Vector3(0, 0, 2500), Quaternion.Euler(-90f, 0f, 0f));
                                break;
                            }
                        //Right
                        case 3:
                            {
                                transform.SetPositionAndRotation(player.transform.position + new Vector3(0, 0, -2500), Quaternion.Euler(90f, 0f, 0f));
                                break;
                            }
                    }
                    transform.LookAt(player.transform.position);
                }
            }
            else
            {
                //If the timer is over, analyse the next target location
                if (++timer * Time.deltaTime > 0.05)
                {
                    timer = 0;

                    //Check if Depth is out of world
                    switch (startLoc)
                    {
                        //Check y
                        case 0:
                        case 1:
                            {
                                if (CheckDifference(player.transform.position.y, transform.position.y) < 500 &&
                                    CheckDifference(player.transform.position.y, transform.position.y) > -500)
                                {
                                    isRushing = false;
                                    isOut = true;
                                    if (startLoc == 0)
                                    {
                                        transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0, 3000, 0), speed);
                                    }
                                    else
                                    {
                                        transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0, -3000, 0), speed);
                                    }
                                }
                                break;
                            }
                        //Check z
                        case 2:
                        case 3:
                            {
                                if (CheckDifference(player.transform.position.z, transform.position.z) < 500 &&
                                    CheckDifference(player.transform.position.z, transform.position.z) > -500)
                                {
                                    isRushing = false;
                                    isOut = true;
                                    if (startLoc == 2)
                                    {
                                        transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0, 0, -3000), speed);
                                    }
                                    else
                                    {
                                        transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0, 0, 3000), speed);
                                    }
                                }
                                break;
                            }
                    }

                    if (!isOut)
                    {
                        //Analyse the distance with each safePoint
                        foreach (GameObject point in safePoints)
                        {
                            x = CheckDifference(player.transform.position.x, point.transform.position.x);
                            z = CheckDifference(player.transform.position.z, point.transform.position.z);
                            if (Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(z, 2)) + 2.5 < safeDistance)
                            {
                                isSafe = true;
                            }
                        }

                        //Check if the player is in a safePoint
                        if (!isSafe)
                        {
                            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
                        }
                        isSafe = false;
                    }
                }
            }
        }
        else
        {
            if(++timer * Time.deltaTime > 10)
            {
                timer = 0;
                isOut = false;
            }
        }
    }

    //Check if the Depth kills the player
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            isRushing = false;
            transform.SetPositionAndRotation(player.transform.position + new Vector3(0, -2500, 0), Quaternion.identity);
        }
    }

    /// <summary>
    /// Calculate the difference between two points
    /// </summary>
    /// <param name="player">Coordinate of the player</param>
    /// <param name="point">Coordinate of the safePoint</param>
    /// <returns>Difference</returns>
    private float CheckDifference(float player, float point)
    {
        if(player > point)
        {
            return player - point;
        }
        else
        {
            return point - player;
        }
    }
}
