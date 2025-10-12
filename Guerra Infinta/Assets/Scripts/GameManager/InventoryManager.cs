using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    //public PlayerInventoryData inventoryData = new PlayerInventoryData();

    public Dictionary<TypeItem, Inventory> ItemDatabase { get; private set; }

    [SerializeField] private Inventory inventoryBattleList;

    //private List<Item> allItems; 

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Cria dicionario para guardar as listas de itens de cada tipo
        ItemDatabase = new Dictionary<TypeItem, Inventory>();
        ItemDatabase[inventoryBattleList.type] = inventoryBattleList;

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

    public void SaveInventory(Inventory item)
    {
        //Debug.Log($"[SAVE] {player.playerId} HP={player.hp}");
        ItemDatabase[inventoryBattleList.type] = item;
    }

    public Inventory LoadInventory(TypeItem type)
    {
        //Debug.Log($"[LOAD] Tentando carregar {playerId}");

        if (ItemDatabase.TryGetValue(type, out Inventory data))
        {
            //Debug.Log($"[LOAD] Achei {data.playerId} HP={data.hp}");
            return data;
        }
        //Debug.Log("[LOAD] Nao encontrado!");
        return null;
    }
}