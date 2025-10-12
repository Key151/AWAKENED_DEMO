using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public Dictionary<string, PlayerData> playerDicioData { get; set; }
    public Dictionary<TypeItem, Inventory> inventoriesDicioData { get; set; }
}