using UnityEngine;

//Script which tell the Depth to chase the player and if the player is in a safeZone
public class RushPlayer : MonoBehaviour {

    //Objects
    public GameObject player;
    private GameObject[] safePoints;
    private Vector3 lastPlayerPoint;
    private Vector3 adding = new Vector3(0, -100, 0);

    //Variables
    public float safeDistance;
    public int speed;
    private float timer;
    private float timerUpdate;
    public bool isAwake = false;
    public bool isRushing = false;
    public bool isSafe = false;
    private byte startPoint;

    //Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
        safePoints = GameObject.FindGameObjectsWithTag("SafePoints");
	}
	
	//Update is called once per frame
	void Update () {
        if(++timerUpdate * Time.deltaTime > 0.05)
        {
            timerUpdate = 0;
            if (isAwake)
            {
                if (isRushing)
                {
                    //Check if the Player is safe
                    foreach(GameObject safePoint in safePoints)
                    {
                        //Up&&Down
                        if(startPoint == 0 || startPoint == 1)
                        {
                            if(Mathf.Sqrt(Mathf.Pow(CheckDifference(player.transform.position.x, safePoint.transform.position.x), 2)
                                + Mathf.Pow(CheckDifference(player.transform.position.z, safePoint.transform.position.z), 2)) < safeDistance){
                                isSafe = true;
                            }
                        }
                        else
                        {
                            if (Mathf.Sqrt(Mathf.Pow(CheckDifference(player.transform.position.x, safePoint.transform.position.x), 2)
                                + Mathf.Pow(CheckDifference(player.transform.position.y, safePoint.transform.position.y), 2)) < safeDistance)
                            {
                                isSafe = true;
                            }
                        }
                    }
                    if (!isSafe)
                    {
                        lastPlayerPoint = player.transform.position + adding;
                    }
                    isSafe = false;

                    //Check if the Depth is near the Player
                    //Up&&Down
                    if (startPoint == 0 || startPoint == 1)
                    {
                        if (Mathf.Sqrt(Mathf.Pow(CheckDifference(player.transform.position.x, transform.position.x), 2)
                            + Mathf.Pow(CheckDifference(player.transform.position.z, transform.position.z), 2)) < 525)
                        {
                            isRushing = false;
                            lastPlayerPoint = player.transform.position + (adding * 30);
                        }
                    }
                    else
                    {
                        if (Mathf.Sqrt(Mathf.Pow(CheckDifference(player.transform.position.x, transform.position.x), 2)
                            + Mathf.Pow(CheckDifference(player.transform.position.y, transform.position.y), 2)) < 525)
                        {
                            isRushing = false;
                            lastPlayerPoint = player.transform.position + (adding * 30);
                        }
                    }
                }

                if(transform.position.y > 2500 || transform.position.y < -2500 || transform.position.z > 2500 || transform.position.z < -2500)
                {
                    isAwake = false;
                }
            }
            else
            {
                if(++timer * Time.deltaTime > 5)
                {
                    timer = 0;
                    startPoint = (byte)Random.Range(0, 3);
                    switch (startPoint)
                    {
                        //Down
                        case 0:
                            adding = new Vector3(0, -100, 0);
                            transform.position = player.transform.position + new Vector3(0, 2500, 0);
                            break;

                        //Up
                        case 1:
                            adding = new Vector3(0, 100, 0);
                            transform.position = player.transform.position + new Vector3(0, -2500, 0);
                            break;

                        //Left
                        case 2:
                            adding = new Vector3(0, 0, -100);
                            transform.position = player.transform.position + new Vector3(0, 0, 2500);
                            break;

                        //Right
                        case 3:
                            adding = new Vector3(0, 0, 100);
                            transform.position = player.transform.position + new Vector3(0, 0, -2500);
                            break;
                    }
                    isAwake = true;
                    isRushing = true;
                }
            }
        }
    }

    //Check if the Depth kills the player
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {

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
