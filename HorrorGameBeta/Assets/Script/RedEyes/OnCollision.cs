using UnityEngine;

/// <summary>
/// Script that kill the Player when it touches the RedEyes
/// </summary>
public class OnCollision : MonoBehaviour {

    //Objects
    public GameObject player;
    public GameObject playerLight;
    public GameObject musicPlayer;
    public GameObject menu;
    public GameObject menuGameOver;
    public AudioClip killRed;
    
    /// <summary>
    /// Method which analyse the collider which collisions it
    /// </summary>
    /// <param name="collision">The collider which collisions this one</param>
    private void OnCollisionEnter(Collision collision)
    {
        //Check if the collider is the Player
        if (collision.collider.tag == "Player")
        {
            player.GetComponent<Escape>().StopGame();
            musicPlayer.GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = killRed;
            GetComponent<AudioSource>().Play();
            player.transform.LookAt(new Vector3(0, 9000, 0));
            Cursor.lockState = CursorLockMode.Confined;
            menu.SetActive(true);
            menuGameOver.SetActive(true);
            GetComponent<CheckSee>().enabled = false;
        }
    }
}
