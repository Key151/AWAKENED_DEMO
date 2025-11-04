using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public string currentSceneName;
    public Dictionary<string, PlayerData> playerDicioData = new Dictionary<string, PlayerData>();
    public Dictionary<TypeItem, Dictionary<NameItem, ItemData>> inventoriesDicioData = new Dictionary<TypeItem, Dictionary<NameItem, ItemData>>();
    public Dictionary<string, bool> dataDialog = new();
    public HashSet<string> defeatedEnemiesSave = new();
    public Dictionary<string, bool> gameStateDicioSave = new Dictionary<string, bool>();

    public static SaveData Data = new SaveData();
}