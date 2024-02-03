using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private int ObjSpawnAmount;
    [SerializeField] private float DelayBetweenObjSpawn;
    [SerializeField] private int spawnForce;
    private int spawnCount;
    [SerializeField] private GameObject Prefab;
    [SerializeField] private GameObject light;
    [SerializeField] private ParticleSystem ParticlePrefab;
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private Animator Chest_Open = null;
    [SerializeField] private Animator ChestUnlock = null;
    [SerializeField] private Animator ChestFullyOpen = null;
    [SerializeField] private AudioClips audioClipObject;
    [SerializeField] private bool CoinChest = false;
    [SerializeField] private bool CrystalChest = false;
    [SerializeField] private bool KeyChest = false;
    [SerializeField] private bool MysteryChest = false;
    [SerializeField] private bool EmptyChest = false;
    [SerializeField] private Vector3 Spread = new Vector3(0.1f, 0.1f, 0.1f);

    


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
        
        if (CoinChest)
        {
            CoinChest = false;
            AudioManager.Instance.PlaySound(audioClipObject.ChestOpen);
            Chest_Open.Play("Chest_Open", 0, 0.0f);

            StartCoroutine(openChest());

            IEnumerator openChest()
            {
                yield return new WaitForSeconds(1);
                    light.SetActive(true);
                AudioManager.Instance.PlaySound(audioClipObject.TaDa);
                    ParticlePrefab.Play();
                //InvokeRepeating("SpawnObject", 0, DelayBetweenObjSpawn);
                //SpawnObject();   
            }
        }
        else if (CrystalChest)
        {
            CrystalChest = false;
            AudioManager.Instance.PlaySound(audioClipObject.ChestOpen);
            Chest_Open.Play("Chest_Open", 0, 0.0f);

            StartCoroutine(openChest());

            IEnumerator openChest()
            {
                yield return new WaitForSeconds(1);
                AudioManager.Instance.PlaySound(audioClipObject.TaDa);
            }
        }
        else if (KeyChest)
        {
            KeyChest = false;
            AudioManager.Instance.PlaySound(audioClipObject.ChestOpen);
            Chest_Open.Play("Chest_Open", 0, 0.0f);

            StartCoroutine(openChest());

            IEnumerator openChest()
            {
                yield return new WaitForSeconds(1);
                AudioManager.Instance.PlaySound(audioClipObject.TaDa);
            }
        }
        else if (MysteryChest)
        {
            MysteryChest = false;
            AudioManager.Instance.PlaySound(audioClipObject.ChestOpen);
            Chest_Open.Play("Chest_Open", 0, 0.0f);

            StartCoroutine(openChest());

            IEnumerator openChest()
            {
                yield return new WaitForSeconds(1);
                AudioManager.Instance.PlaySound(audioClipObject.TaDa);
            }
        }
        else if (EmptyChest)
        {
            EmptyChest = false;
            AudioManager.Instance.PlaySound(audioClipObject.ChestOpen);
            Chest_Open.Play("Chest_Open", 0, 0.0f);

            StartCoroutine(openChest());

            IEnumerator openChest()
            {
                yield return new WaitForSeconds(1);
                AudioManager.Instance.PlaySound(audioClipObject.TaDaBad);
            }
        }
    }
    }

    private void SpawnObject()
    {        
        spawnCount++;
        Vector3 direction = transform.up;
        direction += new Vector3(Random.insideUnitSphere.x, Random.insideUnitSphere.y, Random.insideUnitSphere.z);

        //direction += new Vector3(Random.Range(-Spread.x, Spread.x), Random.Range(-Spread.y, Spread.y), Random.Range(-Spread.z, Spread.z));
        //direction.Normalize();
        GameObject obj = Instantiate(Prefab, spawnLocation.position, Prefab.transform.rotation);

        obj.GetComponent<Rigidbody>().velocity = direction * 45 ;
        if (spawnCount >= ObjSpawnAmount)
        {
            CancelInvoke();
            spawnCount = 0;
        }            
    }
}
