using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Script that chase the Player
/// </summary>
public class Chase : MonoBehaviour {

    //Objects
    public GameObject player;

	//Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
	}

    //When the script is enabled
    private void OnEnable()
    {
        //TODO Play Chase
    }

    //Update is called once per frame
    void Update () {
        GetComponent<Pathfinding>().enabled = false;
        GetComponent<NavMeshAgent>().destination = player.transform.position;
	}
}
