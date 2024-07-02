using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAi : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private int rotateSpeed;
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private Transform[] RatWayPoint;
    private int selectedWaypoint;
    private float timer = 0;


    private void Start()
    {
        Debug.Log("TIMER " + timer);
    }
    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            RatWayPoint[selectedWaypoint].position = new Vector3(0, 0, 0);

            RatWayPoint[selectedWaypoint].position = new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10));

            selectedWaypoint = Random.Range(0, RatWayPoint.Length);
            
            timer = Random.Range(2, 4);
        }
        Vector3 move = Vector3.MoveTowards(transform.position, wayPoints[selectedWaypoint].position, speed * Time.deltaTime);
        //Transform target = ;
        transform.position = move;
        //Vector3 direction = transform.forward;
        Quaternion lookDirection = Quaternion.LookRotation(wayPoints[selectedWaypoint].position - transform.position);
        lookDirection = Quaternion.Euler(0, lookDirection.eulerAngles.y, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, rotateSpeed * Time.deltaTime);
        RaycastHit hit;

        // direction += new Vector3(Random.Range(-BulletSpread.x, BulletSpread.x), Random.Range(-BulletSpread.y, BulletSpread.y), Random.Range(-BulletSpread.z, BulletSpread.z));
        //if (Physics.Raycast(transform.position, direction, out hit, 5.0f))
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.0f))
        {
            if (hit.collider.tag == "Ground")
            {
                Debug.Log("Hit Wall");
                // hitpoint.transform.parent = hit.transform;
            }
        }
    }
}
