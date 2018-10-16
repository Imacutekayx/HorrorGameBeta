using UnityEngine;

/// <summary>
/// Script which manage the rotation of the camera
/// </summary>
public class UWRotation : MonoBehaviour {

    //Variables
    public float sensibility = 2.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    //Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            yaw += sensibility * Input.GetAxis("Mouse X");
            pitch -= sensibility * Input.GetAxis("Mouse Y");
        }
        else
        {
            yaw += sensibility * Input.GetAxis("Mouse XGame");
            pitch -= sensibility * Input.GetAxis("Mouse YGame");
        }
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
