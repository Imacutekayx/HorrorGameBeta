using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Script that manage the Pathfinding of the RedEyes
/// </summary>
public class Pathfinding : MonoBehaviour
{

    //Objects
    private NavMeshAgent agent;
    private readonly Transform target;
    private readonly SphereCollider coll;

    //Variables
    public float wanderRadius;
    public float wanderTimer;
    private float timer;

    /// <summary>
    /// Method that active when the script is enables
    /// </summary>
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    //Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //Check if the current time is more than the wanderTime
        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    /// <summary>
    /// Method which choose a random location to go
    /// </summary>
    /// <param name="origin">Current location</param>
    /// <param name="dist">Maximum distance</param>
    /// <param name="layermask">LayerMask needed</param>
    /// <returns></returns>
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }
}
