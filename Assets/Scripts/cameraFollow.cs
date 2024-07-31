using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    ShakeCamera shakeCamera;
    public Vector3 offset;
    public bool isShakeing;
    delegate void ChangeAngle(Transform t);
    //public static event ChangeAngle changeAngle;

    private void Start()
    {
        shakeCamera = GetComponent<ShakeCamera>();
        //changeAngle += ChangeCameraAngle;
    }
    void Update()
    {    
       // transform.position = target.position + offset;
        Vector3 desiredp = target.position + offset;
        Vector3 smoothedp = Vector3.Lerp(transform.position, desiredp, smoothSpeed * Time.deltaTime);
        transform.position = smoothedp;
    }

    public void ChangeCameraAngle(Transform tmpTarget)
    {
        //offset
    }
}
