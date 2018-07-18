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

	//Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        safePoints = GameObject.FindGameObjectsWithTag("SafePoints");
	}
	
	//Update is called once per frame
	void Update () {
        if (!isRushing)
        {
            if (++timer * Time.deltaTime > 5)
            {
                timer = 0;
                isRushing = true;
                transform.SetPositionAndRotation(player.transform.position + new Vector3(0, -2000, 0), Quaternion.identity);
            }
        }
        else
        {
            if(transform.position.y > 5000)
            {
                isRushing = false;
            }
            //TODO Analyse position of player compared to safePoints
        }
    }

    //Check if the Depth kills the player
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            //TODO GameOver
        }
    }
}
