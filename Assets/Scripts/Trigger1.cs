using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger1 : MonoBehaviour
{
    [SerializeField] private Animator MainGateRight = null;
    [SerializeField] private Animator MainGateLeft = null;
    [SerializeField] private AudioClip doorOpen;
    [SerializeField] private AudioClip doorClose;
    [SerializeField] private string openLeft;
    [SerializeField] private string openRight;
    [SerializeField] private bool openTrig = false;
    [SerializeField] private bool closeTrig = false;
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (openTrig)
            {
                MainGateRight.Play(openRight, 0, 0.0f);
                MainGateLeft.Play(openLeft, 0, 0.0f);
                AudioManager.Instance.PlaySound(doorOpen);
                gameObject.SetActive(false);
            }

            else if (closeTrig)
            {
                MainGateRight.Play(openRight, 0, 0.0f);
                MainGateLeft.Play(openLeft, 0, 0.0f);
                AudioManager.Instance.PlaySound(doorClose);
                gameObject.SetActive(false);
            }
        }
    }
}
