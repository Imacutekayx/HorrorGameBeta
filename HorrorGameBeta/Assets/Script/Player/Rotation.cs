using UnityEngine;

/// <summary>
/// Script which manage the rotation of the camera
/// </summary>
public class Rotation : MonoBehaviour {

    //Variables
    public float sensibility = 2.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    //Update is called once per frame
    void Update()
    {
        yaw += sensibility * Input.GetAxis("Mouse X");
        pitch -= sensibility * Input.GetAxis("Mouse Y");

        if(pitch < 90 && pitch > -90)
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
