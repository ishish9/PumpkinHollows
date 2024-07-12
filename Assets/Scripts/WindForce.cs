using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindForce : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private AudioClips audioClips;
    [SerializeField] private GameObject leaves;

    private void OnTriggerEnter(Collider other)
    {
        AudioManager.Instance.PlaySoundLooped(audioClips.Wind);
        leaves.SetActive(true);
    }

    void OnTriggerStay()
    {
        rb.AddForce(0, 0, -.1f, ForceMode.Impulse);
    }

    private void OnTriggerExit(Collider other)
    {
        AudioManager.Instance.PlaySoundLoopedStop();
        leaves.SetActive(false);
    }
}
