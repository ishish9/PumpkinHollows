using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_Trigger : MonoBehaviour
{
    [SerializeField] private Transform respawnLocation;
    [SerializeField] private Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        rb.Move(respawnLocation.position, Quaternion.identity);
    }
}
