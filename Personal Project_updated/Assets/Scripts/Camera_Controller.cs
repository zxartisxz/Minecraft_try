using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    //Public variable to store a reference to the player game object
    public GameObject player;

    // camera transform
    public Transform cam_Transform;
    //Private variable to store the offset distance between the...
    //player and camera

    private Vector3 camera_Offset;
    private int look_Level = 0;
    public float SmoothTime = 0.3f;

    //This value will change at runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

        // Calculate and store values by getting the distance between...
        // the player's position and camera's position
        camera_Offset = transform.position - player.transform.position;
     
    }

    // LateUpdate is called after Update each frame
    //void LateUpdate()
    void FixedUpdate()
    {
        // Set position of the camera's transform to be the same as...
        // player's, but offset by the calculated offset distance.
        //looking down
        /*
      if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && look_Level < 1 )
       {
           camera_Offset += new Vector3(0, -5, 0) * Time.deltaTime * 30;
           look_Level += 1;
       }
      //Looking up
       else if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && look_Level > -1 )
       {
           camera_Offset += new Vector3(0, 5, 0) * Time.deltaTime * 30;
           look_Level -= 1;
       }

      else */
        
        {
            transform.position = player.transform.position + camera_Offset;
        }
        //transform.LookAt(player.transform);
    }

}
