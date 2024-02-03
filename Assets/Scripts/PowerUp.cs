using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private AudioClips audioClips;
    [SerializeField] private GameObject PickUpEffect;
    [SerializeField] private string powerupType;
    [SerializeField] private Animator Big = null;
    [SerializeField] private Animator Small = null;


    public GameObject[] PowerUpsObjs;
    private controller playerController;

    private void OnTriggerEnter(Collider hitbox)
    {
        if (hitbox.CompareTag("Player"))
        {
            PickUp(hitbox);
        }       
    }

    private void PickUp(Collider player)
    {
        AudioManager.Instance.PlaySound(audioClips.GetPowerUp);
        Instantiate(PickUpEffect, transform.position, Quaternion.identity);
        playerController = player.GetComponent<controller>();
        switch (powerupType)
        {
            case "Big":
                // playerTransform = player.GetComponent<Transform>();
                Big.Play("Big", 0, 0.0f);

                //player.transform.localScale *= 2f;
                break;
            case "Small":
                Small.Play("Small", 0, 0.0f);

                break;
            case "Heavy":

                break;
            case "Light":

                break;
            case "Metal":
                break;
        }
        Destroy(gameObject);
    }
}
