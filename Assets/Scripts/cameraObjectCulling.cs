using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraObjectCulling : MonoBehaviour
{
    private Transform Camera;

    void Start()
    {
        Camera = transform;
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 direction = transform.forward;
        //direction += new Vector3(Random.Range(-BulletSpread.x, BulletSpread.x), Random.Range(-BulletSpread.y, BulletSpread.y), Random.Range(-BulletSpread.z, BulletSpread.z));
        if (Physics.Raycast(Camera.transform.position, direction, out hit, 9500.0f))
        {
            if (hit.collider.tag == "Player")
            {
                Debug.Log("I can See Player");
                //var hitpoint = Instantiate(HitPrefab, hit.point, SpawnLocation.rotation);
                //hitpoint.transform.parent = hit.transform;
            }else
            {
                Debug.Log("I Can't See Player!!!!");
            }
        }
    }
}
