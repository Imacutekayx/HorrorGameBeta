using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class which manage the controls and the value of the sliders
/// </summary>
public class ControlsManager : MonoBehaviour{

    //Objects
    public GameObject player;
    public GameObject playerLight;
    public GameObject battery;
    public GameObject s0;
    public GameObject s1;
    public GameObject s2;
    public GameObject sliderMusic;
    public GameObject sliderSound;
    public GameObject sliderGame;
    public GameObject menu;
    public GameObject menuOption;
    public GameObject instructions;
    private GameObject currentKey;
    private GameObject currentBtn;
    private GameObject[] keyShows;
    private GameObject[] btnShows;
    private Controls controls;

    //Variables
    private int x;

    /// <summary>
    /// Method which assign the values in the XML to the game
    /// </summary>
    public void StartAssign () {
        player = GameObject.FindWithTag("Player");
        playerLight = GameObject.FindWithTag("PlayerLight");
        s0 = GameObject.FindWithTag("S0");
        s1 = GameObject.FindWithTag("S1");
        s2 = GameObject.FindWithTag("S2");
        controls = Controls.LoadFromFile(Application.dataPath + "/Save/controls.xml");

        //Keys
        player.GetComponent<Movement>().forward = controls.lstKeys[0].keyValue;
        player.GetComponent<Movement>().behind = controls.lstKeys[1].keyValue;
        player.GetComponent<Movement>().left = controls.lstKeys[2].keyValue;
        player.GetComponent<Movement>().right = controls.lstKeys[3].keyValue;
        player.GetComponent<Movement>().crouch = controls.lstKeys[4].keyValue;
        player.GetComponent<Movement>().sprint = controls.lstKeys[5].keyValue;
        s0.GetComponent<Switch>().interact = controls.lstKeys[6].keyValue;
        s1.GetComponent<Switch>().interact = controls.lstKeys[6].keyValue;
        s2.GetComponent<Switch>().interact = controls.lstKeys[6].keyValue;
        battery.GetComponent<Battery>().interact = controls.lstKeys[6].keyValue;
        instructions.GetComponent<Instructions>().interact = controls.lstKeys[6].keyValue;
        playerLight.GetComponent<ToggleLight>().key = controls.lstKeys[7].keyValue;
        player.GetComponent<Escape>().key = controls.lstKeys[8].keyValue;

        //Buttons
        player.GetComponent<Movement>().forwardBtn = controls.lstButtons[0].btnValue;
        player.GetComponent<Movement>().behindBtn = controls.lstButtons[1].btnValue;
        player.GetComponent<Movement>().leftBtn = controls.lstButtons[2].btnValue;
        player.GetComponent<Movement>().rightBtn = controls.lstButtons[3].btnValue;
        player.GetComponent<Movement>().crouchBtn = controls.lstButtons[4].btnValue;
        player.GetComponent<Movement>().sprintBtn = controls.lstButtons[5].btnValue;
        s0.GetComponent<Switch>().interactBtn = controls.lstButtons[6].btnValue;
        s1.GetComponent<Switch>().interactBtn = controls.lstButtons[6].btnValue;
        s2.GetComponent<Switch>().interactBtn = controls.lstButtons[6].btnValue;
        battery.GetComponent<Battery>().interactBtn = controls.lstButtons[6].btnValue;
        instructions.GetComponent<Instructions>().interactBtn = controls.lstButtons[6].btnValue;
        menu.GetComponent<MenuController>().accept = controls.lstButtons[6].btnValue;
        playerLight.GetComponent<ToggleLight>().button = controls.lstButtons[7].btnValue;
        player.GetComponent<Escape>().button = controls.lstButtons[8].btnValue;
        menu.GetComponent<MenuController>().escape = controls.lstButtons[8].btnValue;

        //Sliders
        sliderMusic.GetComponent<UnityEngine.UI.Slider>().value = controls.lstSliders[0].sliderValue;
        sliderSound.GetComponent<UnityEngine.UI.Slider>().value = controls.lstSliders[1].sliderValue;
        sliderGame.GetComponent<UnityEngine.UI.Slider>().value = controls.lstSliders[2].sliderValue;
        menuOption.GetComponent<ChangeSettings>().ChangeMusicVolume(controls.lstSliders[0].sliderValue);
        menuOption.GetComponent<ChangeSettings>().ChangeSoundVolume(controls.lstSliders[1].sliderValue);
        menuOption.GetComponent<ChangeSettings>().ChangeSensibility(controls.lstSliders[2].sliderValue);
    }
	
    /// <summary>
    /// Method which show the values in the XML in the ControlsMenu
    /// </summary>
	public void ChargeKeys()
    {
        x = 0;
        keyShows = GameObject.FindGameObjectsWithTag("Keyshow");
        btnShows = GameObject.FindGameObjectsWithTag("BtnShow");
        controls = Controls.LoadFromFile(Application.dataPath + "/Save/controls.xml");
        foreach(GameObject keyShow in keyShows)
        {
            keyShow.GetComponent<Text>().text = Convert.ToString(controls.lstKeys[x].keyValue);
            btnShows[x].GetComponent<Text>().text = Convert.ToString(controls.lstButtons[x].btnValue);
            ++x;
        }
    }

    /// <summary>
    /// Method which active when an key is pressed and a control is assigned
    /// </summary>
    private void OnGUI()
    {
        if(currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                ChangeKey(currentKey.name, e.keyCode);
            }
        }
        if(currentBtn != null)
        {
            Event e = Event.current;
            if(e.functionKey)
            {
                ChangeBtn(currentBtn.name, e.keyCode);
            }
        }
    }

    /// <summary>
    /// Method which change the control that the user want to change
    /// </summary>
    /// <param name="clicked">Object with the name of the key that the User wants to change</param>
    public void ChangeKey(GameObject clicked)
    {
        currentKey = clicked;
    }

    /// <summary>
    /// Method which change the control that the user want to change
    /// </summary>
    /// <param name="clicked">Object with the name of the button that the User wants to change</param>
    public void ChangeBtn(GameObject clicked)
    {
        currentBtn = clicked;
    }

    /// <summary>
    /// Method which change the value of a control depending of the User
    /// </summary>
    /// <param name="name">Name of the control</param>
    /// <param name="value">KeyCode that will be assigned</param>
    public void ChangeKey(string name, KeyCode value)
    {
        controls = Controls.LoadFromFile(Application.dataPath + "/Save/controls.xml");
        //Analyse each key in the list
        foreach(Keys key in controls.lstKeys)
        {
            //Check if the name of the Control is the same as the key's name and change it
            if(key.keyName == name)
            {
                key.keyValue = value;
                currentKey.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = value.ToString();
                //Assign the value of the new key where it's needed
                switch (key.keyName)
                {
                    case "forward":
                        {
                            player.GetComponent<Movement>().forward = value;
                            break;
                        }
                    case "behind":
                        {
                            player.GetComponent<Movement>().behind = value;
                            break;
                        }
                    case "left":
                        {
                            player.GetComponent<Movement>().left = value;
                            break;
                        }
                    case "right":
                        {
                            player.GetComponent<Movement>().right = value;
                            break;
                        }
                    case "crouch":
                        {
                            player.GetComponent<Movement>().crouch = value;
                            break;
                        }
                    case "sprint":
                        {
                            player.GetComponent<Movement>().sprint = value;
                            break;
                        }
                    case "interact":
                        {
                            s0.GetComponent<Switch>().interact = value;
                            s1.GetComponent<Switch>().interact = value;
                            s2.GetComponent<Switch>().interact = value;
                            battery.GetComponent<Battery>().interact = value;
                            break;
                        }
                    case "light":
                        {
                            playerLight.GetComponent<ToggleLight>().key = value;
                            break;
                        }
                    case "escape":
                        {
                            player.GetComponent<Escape>().key = value;
                            break;
                        }
                }
            }
        }
        controls.Save(Application.dataPath + "/Save/controls.xml");
    }

    /// <summary>
    /// Method which change the value of a control depending of the User
    /// </summary>
    /// <param name="name">Name of the control</param>
    /// <param name="value">String that will be assigned</param>
    public void ChangeBtn(string name, KeyCode value)
    {
        controls = Controls.LoadFromFile(Application.dataPath + "/Save/controls.xml");
        //Analyse each key in the list
        foreach (Button button in controls.lstButtons)
        {
            //Check if the name of the Control is the same as the key's name and change it
            if (button.btnName == name)
            {
                button.btnValue = value;
                currentBtn.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = value.ToString();
                //Assign the value of the new key where it's needed
                switch (button.btnName)
                {
                    case "forward":
                        {
                            player.GetComponent<Movement>().forwardBtn = value;
                            break;
                        }
                    case "behind":
                        {
                            player.GetComponent<Movement>().behindBtn = value;
                            break;
                        }
                    case "left":
                        {
                            player.GetComponent<Movement>().leftBtn = value;
                            break;
                        }
                    case "right":
                        {
                            player.GetComponent<Movement>().rightBtn = value;
                            break;
                        }
                    case "crouch":
                        {
                            player.GetComponent<Movement>().crouchBtn = value;
                            break;
                        }
                    case "sprint":
                        {
                            player.GetComponent<Movement>().sprintBtn = value;
                            break;
                        }
                    case "interact":
                        {
                            s0.GetComponent<Switch>().interactBtn = value;
                            s1.GetComponent<Switch>().interactBtn = value;
                            s2.GetComponent<Switch>().interactBtn = value;
                            battery.GetComponent<Battery>().interactBtn = value;
                            break;
                        }
                    case "light":
                        {
                            playerLight.GetComponent<ToggleLight>().button = value;
                            break;
                        }
                    case "escape":
                        {
                            player.GetComponent<Escape>().button = value;
                            break;
                        }
                }
            }
        }
        controls.Save(Application.dataPath + "/Save/controls.xml");
    }
}
