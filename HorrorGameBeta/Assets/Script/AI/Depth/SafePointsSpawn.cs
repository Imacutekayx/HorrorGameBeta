using UnityEngine;

/// <summary>
/// Script which create the safePoints
/// </summary>
public class SafePointsSpawn : MonoBehaviour {

    //Objects
    public GameObject safe;
    public GameObject safeO2;
    private GameObject temp;

    //Variables
    private int space;
    private int nbrPoints = 10;
    private int rngResult;
    private float lastZ;

    //TODO delete Update
    private bool first = true;
    private void Update()
    {
        if (first)
        {
            first = false;
            Spawn();
        }
    }

    /// <summary>
    /// Method which calculate the position of the safePoints, theirs attributes and create them
    /// </summary>
    public void Spawn()
    {
        for(int x = 0; x < nbrPoints; ++x)
        {
            rngResult = Random.Range(1, 100);
            if(space == 2 || (space == 1 && rngResult < 50) || space == 0 && rngResult < 25)
            {
                space = 0;
                temp = Instantiate(safeO2);
            }
            else
            {
                ++space;
                temp = Instantiate(safe);
            }

            temp.tag = "SafePoints";
            temp.transform.SetPositionAndRotation(new Vector3(200 * x + 200, 0, lastZ += Random.Range(5, 50)), Quaternion.identity);
        }

        //TODO CreateEnd
    }
}
