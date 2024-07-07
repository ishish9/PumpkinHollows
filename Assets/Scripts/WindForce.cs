using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindForce : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private AudioClips audioClips;

    void OnTriggerStay()
    {
        rb.AddForce(0, 0, -.1f, ForceMode.Impulse);
        AudioManager.Instance.PlaySound(audioClips.Wind);
    }

    private void OnTriggerExit(Collider other)
    {
        AudioManager.Instance.PlaySoundLoopedStop();
    }
}
