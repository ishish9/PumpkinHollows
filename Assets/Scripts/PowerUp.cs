using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerupType powerupType;
    [SerializeField] private AudioClips audioClips;
    [SerializeField] private GameObject PickUpEffect;
    [SerializeField] private Animator Big = null;
    [SerializeField] private Animator Small = null;
    [SerializeField] private int[] num = new int[4];
    public GameObject[] PowerUpsObjs;
    private controller playerController;

    private void Update()
    {
        transform.Rotate(0, 200 * Time.deltaTime, 0, Space.Self);
        Vector3 p = transform.position;
        p.y = .1f * Mathf.Cos(Time.time * 3.5f);
        transform.position = p;
    }

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
            case PowerupType.Big:
                // playerTransform = player.GetComponent<Transform>();
                Big.Play("Big", 0, 0.0f);

                //player.transform.localScale *= 2f;
                break;
            case PowerupType.Small:
                Small.Play("Small", 0, 0.0f);

                break;
            case PowerupType.Heavy:

                break;
            case PowerupType.Light:

                break;
            case PowerupType.Metal:
                break;
        }
        Destroy(gameObject);
    }

    public enum PowerupType
        {
            Big,
            Small,
            Heavy,
            Light,
            Metal, 
            Subterain,
        }
}
