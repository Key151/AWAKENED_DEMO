using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "inventory")]
public class Inventory : ScriptableObject
{
    public TypeItem type = TypeItem.BattleItem;
    public List<ApplyItem> inventoryList;
}