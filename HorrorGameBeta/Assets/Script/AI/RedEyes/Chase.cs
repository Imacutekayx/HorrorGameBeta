using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Script that chase the Player
/// </summary>
public class Chase : MonoBehaviour {

    //Objects
    public GameObject player;
    public AudioClip chase;

	//Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
	}

    //When the script is enabled
    private void OnEnable()
    {
        GetComponent<AudioSource>().clip = chase;
        GetComponent<AudioSource>().Play();
    }

    //Update is called once per frame
    void Update () {
        GetComponent<Pathfinding>().enabled = false;
        GetComponent<NavMeshAgent>().destination = player.transform.position;
	}
}
