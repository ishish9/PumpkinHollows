using UnityEngine;

public enum ItemType
{
    Collectables,
    Type,
    Apple,
    Book,
    Key,
    Default
}

public abstract class InventoryItems : ScriptableObject
{
    [Header("Inventory Items")]
    public ItemType type;
    public GameObject prefab;
    [TextArea(15,20)]
    public string description;

}
