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

    private void Start()
    {
        shakeCamera = GetComponent<ShakeCamera>();
    }
    void Update()
    {
        if (shakeCamera.ShakeStatus() == false)
        {
            transform.position = target.position + offset;
        }
        else
        {

        }


    }
}



/*
public Transform target;
public float smoothSpeed = 0.125f;

public Vector3 offset;


void LateUpdate()
{
    transform.position = target.position + offset;


}


/*void LateUpdate()
{
    Vector3 desiredp = target.position + offset;
    Vector3 smoothedp = Vector3.Lerp(transform.position, desiredp, smoothSpeed * Time.deltaTime);
    transform.position = smoothedp;


}
*/