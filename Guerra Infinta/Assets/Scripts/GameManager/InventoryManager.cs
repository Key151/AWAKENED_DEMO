using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    //public PlayerInventoryData inventoryData = new PlayerInventoryData();
    private Dictionary<NameItem, ItemData> ListItem = new Dictionary<NameItem, ItemData>();
    public Dictionary<TypeItem, Dictionary<NameItem, ItemData>> ItemDatabase { get; private set; }

    [SerializeField] private Inventory inventoryBattleList;

    private ItemData ItemData;

    //private List<Item> allItems; 

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        //DontDestroyOnLoad(gameObject);

        // Cria dicionario para guardar as listas de itens de cada tipo
        if (ItemDatabase == null) ItemDatabase = new Dictionary<TypeItem, Dictionary<NameItem, ItemData>>();

        foreach(var item in inventoryBattleList.inventoryList)
        {  
            ItemData = new ItemData
            {
                id = item.ID,
                quantity = item.Quantity
            };
            ListItem[item.ID] = ItemData;
        }

        ItemDatabase[inventoryBattleList.type] = ListItem;

        //SaveData.Data.inventoriesDicioData = ItemDatabase;
    }

    //public void AddItem(string itemId, int amount = 1)
    //{
    //    var slot = inventoryData.items.Find(s => s.itemId == itemId);
    //    if (slot != null)
    //    {
    //        slot.quantity += amount;
    //    }
    //    else
    //    {
    //        inventoryData.items.Add(new ItemSlot { itemId = itemId, quantity = amount });
    //    }
    //}

    //public void UseItem(string itemId)
    //{
    //    var slot = inventoryData.items.Find(s => s.itemId == itemId);
    //    if (slot != null && slot.quantity > 0)
    //    {
    //        slot.quantity--;
    //    }
    //}

    public void SaveInventory()
    {
        //Debug.Log($"[SAVE] {player.playerId} HP={player.hp}");
        //ItemDatabase[inventoryBattleList.type] = item;

        foreach (var itens in inventoryBattleList.inventoryList)
        {
            ItemData = new ItemData
            {
                id = itens.ID,
                quantity = itens.Quantity
            };
            ListItem[itens.ID] = ItemData;
        }
    }

    public Dictionary<NameItem, ItemData> LoadInventory(TypeItem type)
    {
        //Debug.Log($"[LOAD] Tentando carregar {playerId}");

        if (ItemDatabase.TryGetValue(type, out Dictionary<NameItem, ItemData> data))
        {
            //Debug.Log($"[LOAD] Achei {data.playerId} HP={data.hp}");
            return data;
        }
        //Debug.Log("[LOAD] Nao encontrado!");
        return null;
    }

    public void StartGame(Inventory inventory)
    {
        inventoryBattleList.inventoryList.Clear();
        foreach (ApplyItem item in inventory.inventoryList)
        {
            inventoryBattleList.inventoryList.Add(item);
            //inventoryBattleList.inventoryList.Add(ApplyItem.CreateInstance();
        }
        
    }
}