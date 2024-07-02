using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class RatAi_V2 : MonoBehaviour
{
    [SerializeField] private List<int> RatNumber = new List<int>();
    [SerializeField] private int speed;
    [SerializeField] private int rotateSpeed;
    [SerializeField] private Transform[] wayPoints = new Transform[4];
    [SerializeField] private Transform[] RatWayPoint;
    [SerializeField] string[] str = { "hgihgd" , "sddfsd", "HIIIIII"};
    public int[] intarray = new int[3];
    private int selectedWaypoint;
    private float timer = 0;
    public hi ti;    
    private void Start()
    {
        Console.WriteLine("HIIII");
        Debug.Log("fsdfsdfsdf");
        // str[1] = "dfsdfs";
        //Debug.Log(str[1]);
        //intarray[0] = 911;
        //Debug.Log("InArray = " + intarray[0]);
        RatNumber.Remove(RatNumber[1]);


    }

    public enum hi
    {
        hi,
        ho,
        of,
        to,
        work,
        we,
        go
    }
    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Vector3 direction = new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10));
            //transform.position += new Vector3(direction.x, direction.y, speed * Time.deltaTime);
            
            timer = Random.Range(2, 4);
        }
        
        //Quaternion lookDirection = Quaternion.LookRotation(wayPoints[selectedWaypoint].position - transform.position);
       // lookDirection = Quaternion.Euler(0, lookDirection.eulerAngles.y, 0);
       // transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, rotateSpeed * Time.deltaTime);
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
