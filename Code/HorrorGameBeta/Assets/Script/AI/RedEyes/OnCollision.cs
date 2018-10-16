using UnityEngine;

/// <summary>
/// Script that kill the Player when it touches the RedEyes
/// </summary>
public class OnCollision : MonoBehaviour {

    //Objects
    public GameObject player;
    public GameObject playerLight;
    public GameObject kid;
    public GameObject musicPlayer;
    public GameObject menu;
    public GameObject menuGameOver;
    public GameObject menuOptions;
    public GameObject userLayout;
    public GameObject battery;
    public GameObject newCurrentBtn;
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
            menu.SetActive(true);
            menu.GetComponent<MenuController>().SetNewBtn(true);
            menu.GetComponent<MenuController>().localLayer = 3;
            menu.GetComponent<MenuController>().currentBtn = newCurrentBtn;
            menu.GetComponent<MenuController>().SetNewBtn(false);
            menuOptions.SetActive(false);
            menuGameOver.SetActive(true);
            userLayout.SetActive(false);
            battery.transform.SetPositionAndRotation(new Vector3(22f, -22f, -10f), Quaternion.Euler(90, 90, 0));
            kid.GetComponent<CheckSee>().enabled = false;
            GetComponent<OnCollision>().enabled = false;
        }
    }
}
