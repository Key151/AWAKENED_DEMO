using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "inventory")]
public class InventoryList : ScriptableObject
{
    public List<Item> inventoryList;
}