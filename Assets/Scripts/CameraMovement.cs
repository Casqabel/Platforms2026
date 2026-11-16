using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 offset;
    [SerializeField] float smoothTime;
    Vector3 smoothDampVelocity;
    // Start is called before the first frame update
    void Start()
    {
     offset=transform.position-player.position;   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=Vector3.SmoothDamp(transform.position, player.position+offset,
        ref smoothDampVelocity, smoothTime);
    }
}
