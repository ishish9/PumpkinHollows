using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private AudioClips audioClips;
    PlayerInputActions playerActionMap;
    [SerializeField] private GameObject InventoryUI;
    [SerializeField] private GameObject InventoryFullObj;
    [SerializeField] private GameObject SeedOBJ;
    [SerializeField] private GameObject CoinOBJ;
    [SerializeField] private GameObject[] InventorySlots = new GameObject [5];
    private TextMeshProUGUI text;


    private void Awake()
    {
        text = InventoryFullObj.GetComponent<TextMeshProUGUI>(); 
        playerActionMap = new PlayerInputActions();
        playerActionMap.Player.Inventory.performed += OnInventory;
    }

    private void OnEnable()
    {
        playerActionMap.Player.Enable();
        InventoryItem.OnInventoryItemCollect += RecieveInventoryItem;
    }

    private void OnDisable()
    {
        playerActionMap.Player.Disable();
        InventoryItem.OnInventoryItemCollect -= RecieveInventoryItem;
    }

    public void RecieveInventoryItem(Transform itemTransform , Rigidbody itemRB)
    {
        for (int i = 0; i < InventorySlots.Length; i++)
        {
            if (!InventorySlots[i].activeInHierarchy)
            {
                InventorySlots[i].SetActive(true);
                // itemRB.MovePosition(InventorySlots[i].transform.position);
                itemTransform.position = InventorySlots[i].transform.position;
                AudioManager.instance.PlaySound(audioClips.InventoryPickup);
                return;            
            }
            else if (i == 4)
            {
                
                if (!InventoryFullObj.activeInHierarchy)
                {
                    InventoryFullObj.SetActive(true);
                    text.text = "<Fade>Inventory Full!<fade>";
                }
                else
                {
                    InventoryFullObj.SetActive(false);
                    InventoryFullObj.SetActive(true);
                    text.text = "<fade>Inventory Full!<fade>";
                }
            }          
        }       
    }

    public void RemoveInventoryItem(string itemName)
    {
        for (int i = 0; i < InventorySlots.Length; i++)
        {
            if (!InventorySlots[i].activeInHierarchy)
            {
                InventorySlots[i].SetActive(true);
                // itemRB.MovePosition(InventorySlots[i].transform.position);
                //itemTransform.position = InventorySlots[i].transform.position;
                AudioManager.instance.PlaySound(audioClips.InventoryPickup);
                return;
            }
            else if (i == 4)
            {
               // InventoryFullObj.SetActive(true);
                if (InventoryFullObj.activeSelf == false)
                {
                    InventoryFullObj.SetActive(true);
                }
                else
                {
                    InventoryFullObj.SetActive(false);
                    InventoryFullObj.SetActive(true);
                }
            }
        }
    }

    public void OnInventory(InputAction.CallbackContext contex)
    {
       if (InventoryUI.activeSelf == false)
        {
            InventoryUI.SetActive(true);
            SeedOBJ.SetActive(true);
            CoinOBJ.SetActive(true);
            AudioManager.instance.ChangeMusicPitch(3f, false);
        }
        else
        {
            InventoryUI.SetActive(false);
            SeedOBJ.SetActive(false);
            CoinOBJ.SetActive(false);
            AudioManager.instance.ChangeMusicPitch(0f, true);
        }
    }
}
   
