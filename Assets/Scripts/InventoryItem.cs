using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public delegate void Score(Transform transform, Rigidbody rb);
    public static event Score OnInventoryItemCollect;
    private bool rotate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            OnInventoryItemCollect(gameObject.transform, rb);
            rotate = true;
        }
    }

    private void Update()
    {
        if (rotate)
        {
            transform.Rotate(0, 200 * Time.deltaTime, 0, Space.Self);
        }
    }
}
