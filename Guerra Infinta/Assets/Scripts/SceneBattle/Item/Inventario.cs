using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "inventory")]
public class InventoryBattleList : ScriptableObject
{
    public List<ApplyItem> inventoryList;
}