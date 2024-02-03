using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    InventoryItems inventoryItems;
    PlayerInputActions playerActionMap;
    [SerializeField] private GameObject InventoryUI;

    private void Awake()
    {
        playerActionMap = new PlayerInputActions();
        playerActionMap.Player.Inventory.performed += OnInventory;
    }

    private void OnEnable()
    {
        playerActionMap.Player.Enable();
    }

    private void OnDisable()
    {
        playerActionMap.Player.Disable();
    }

    public void OnInventory(InputAction.CallbackContext contex)
    {
       if (InventoryUI.activeSelf == false)
        {
            InventoryUI.SetActive(true);
            AudioManager.Instance.ChangeMusicPitch(5f, false);
        }
        else
        {
            InventoryUI.SetActive(false);
            AudioManager.Instance.ChangeMusicPitch(0f, true);
        }
    }
}
   
