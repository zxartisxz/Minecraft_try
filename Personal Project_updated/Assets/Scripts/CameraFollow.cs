using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Camera will follow targer/player
    public Transform target;
    //Camera transform
    public Transform cam_Transform;
    //Offset between camera and target
    public Vector3 offset;
    //Change this value to get desired smoothness
    public float smooth_Time = 0.3f;

    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        offset = cam_Transform.position - target.position;
    }
    //void SmoothUpdate()
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 target_Position = target.position + offset;
        cam_Transform.position = Vector3.SmoothDamp(transform.position, target_Position, ref velocity, smooth_Time);

        //update rotation
        transform.LookAt(target);
    }
}
