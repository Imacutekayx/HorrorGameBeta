using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class which manage the controller in the menu
/// </summary>
public class MenuController : MonoBehaviour {

    //Objects
    public GameObject menu;
    public GameObject menuOptions;
    public GameObject currentBtn;
    public AudioClip onMenu;
    public AudioClip click;
    public Material basic;
    public Material on;
    private AudioSource audioSource;

    //Variables
    public KeyCode accept;
    public KeyCode escape;
    private float timer;
    private float timerEsc;
    private int layer = -1;
    private int localLayer;
    private int tempChildCount;
    private int tempCurrentIndex;

    //Use this for initialization
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SetNewBtn(false);
    }

    //Update is called once per frame
    void Update()
    {
        //MoveUp
        if (Input.GetAxis("Vertical") == 1)
        {
            //Check if the time is over
            if (++timer * Time.deltaTime > 0.25)
            {
                timer = 0;
                audioSource.clip = onMenu;
                audioSource.Play();
                tempCurrentIndex = GetCurrentBtn(layer, localLayer, currentBtn.name);
                //Check if there is a button above the current one
                if (tempCurrentIndex > 0)
                {
                    SetNewBtn(true);
                    currentBtn = transform.GetChild(localLayer).GetChild(tempCurrentIndex - 1).gameObject;
                    SetNewBtn(false);
                }
            }
        }

        //MoveDown
        if (Input.GetAxis("Vertical") == -1)
        {
            //Check if the time is over
            if (++timer * Time.deltaTime > 0.25)
            {
                timer = 0;
                audioSource.clip = onMenu;
                audioSource.Play();
                //Count the number of buttons
                for(int x = 0; x < transform.GetChild(localLayer).childCount; ++x)
                {
                    //TODO Fix out of buttons exception
                    if(transform.GetChild(localLayer).GetChild(x).tag == "Button")
                    {
                        ++tempChildCount;
                    }
                }
                tempCurrentIndex = GetCurrentBtn(layer, localLayer, currentBtn.name);
                //Check if there is a button under the current one
                if (tempCurrentIndex < tempChildCount - 1)
                {
                    SetNewBtn(true);
                    currentBtn = transform.GetChild(localLayer).GetChild(tempCurrentIndex + 1).gameObject;
                    SetNewBtn(false);
                }
                tempChildCount = 0;
            }
        }

        //Accept
        if (Input.GetKeyDown(accept))
        {
            timer = 0.5f / Time.deltaTime;
            audioSource.clip = click;
            audioSource.Play();
            currentBtn.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
            GetNewBtn(currentBtn.name, true);
        }

        //Escape
        if (++timerEsc *Time.deltaTime > 0.5)
        {
            if (Input.GetKeyDown(escape) && menuOptions.GetComponent<ToOptions>().inGame)
            {
                timer = 0.5f / Time.deltaTime;
                timerEsc = 0;
                menuOptions.GetComponent<ToOptions>().Validate();
            }
        }
    }

    /// <summary>
    /// Method which get the new currentBtn
    /// </summary>
    /// <param name="name">Name of the button</param>
    /// <param name="accept">If the user is pressing the acceptKey</param>
    private void GetNewBtn(string name, bool accept)
    {
        //Check if the user pressed the acceptKey
        if (accept)
        {
            //Analyse the name of the button
            switch (name)
            {
                case "Start":
                    {
                        localLayer = 0;
                        layer = 1;
                        break;
                    }
                case "Options":
                    {
                        localLayer = 1;
                        layer = 1;
                        SetNewBtn(true);
                        currentBtn = transform.GetChild(1).GetChild(0).gameObject;
                        SetNewBtn(false);
                        break;
                    }
                case "Controls":
                    {
                        localLayer = 2;
                        layer = 1;
                        SetNewBtn(true);
                        currentBtn = transform.GetChild(2).GetChild(0).gameObject;
                        SetNewBtn(false);
                        break;
                    }
                case "Next":
                    {
                        currentBtn = transform.GetChild(0).GetChild(0).gameObject;
                        SetNewBtn(false);
                        break;
                    }
                case "ValidateOpt":
                    {
                        if (!menuOptions.GetComponent<ToOptions>().inGame)
                        {
                            GetNewBtn(name, false);
                        }
                        break;
                    }
                case "BackOpt":
                case "ValidateCon":
                case "BackGam":
                    {
                        GetNewBtn(name, false);
                        break;
                    }
            }
        }
        else
        {
            //Analyse the current layer of the menu
            if (layer == 1)
            {
                SetNewBtn(true);
                currentBtn = transform.GetChild(0).GetChild(localLayer).gameObject;
                SetNewBtn(false);
                localLayer = 0;
            }
        }
    }

    /// <summary>
    /// Method which set the new currentBtn
    /// </summary>
    /// <param name="old">If we are changing the old button</param>
    private void SetNewBtn(bool old)
    {
        //Check if this is the old button
        if (old)
        {
            currentBtn.transform.GetChild(0).GetComponent<Text>().material = basic;
        }
        else
        {
            currentBtn.transform.GetChild(0).GetComponent<Text>().material = on;
        }
    }

    /// <summary>
    /// Get the current button's index
    /// </summary>
    /// <param name="layer">Current layer</param>
    /// <param name="localLayer">Base layer</param>
    /// <param name="name">Name of the button</param>
    /// <returns>Index of the bouton</returns>
    private int GetCurrentBtn(int layer, int localLayer, string name)
    {
        for (int x = 0; x < transform.GetChild(localLayer).childCount; ++x)
        {
            if (transform.GetChild(localLayer).GetChild(x).name == name)
            {
                return x;
            }
        }
        return 0;
    }
}
