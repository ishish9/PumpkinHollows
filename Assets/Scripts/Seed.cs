using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    [SerializeField] private GameObject Prefab;
    public delegate void Score(int num);
    public static event Score OnScore;

    void Update()
    {
        transform.Rotate(0f, 200f * Time.deltaTime, 0f, Space.Self);
    }

    private void OnTriggerEnter()
    {
        Instantiate(Prefab, transform.position, transform.rotation);     
        OnScore(1);
        gameObject.SetActive(false);
    }
}
