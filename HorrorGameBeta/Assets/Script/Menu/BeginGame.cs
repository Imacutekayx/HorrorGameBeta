using UnityEngine;

/// <summary>
/// Script that will start the GameMenu
/// </summary>
public class BeginGame : MonoBehaviour {
    public GameObject panelMyuuji;
    public GameObject panelBase;
    public GameObject musicPlayer;
    public GameObject panelOptions;
	
	/// <summary>
    /// Method that active the panel of the main menu
    /// </summary>
	public void Begin () {
        panelMyuuji.SetActive(false);
        panelBase.SetActive(true);
        panelOptions.GetComponent<ChangeSettings>().controls = Controls.LoadFromFile(Application.dataPath + "/Save/controls.xml");
        musicPlayer.GetComponent<AudioSource>().Play();
        GetComponent<BeginGame>().enabled = false;
	}
}
