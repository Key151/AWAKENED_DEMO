using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class GameManager: MonoBehaviour
{
    private static string SavePath => Path.Combine(Application.persistentDataPath, "save.json");

    public static void Save(SaveData data)
    {
        //Save do que precisa
        data.playerDicioData = PlayerManager.Instance.PlayerDataSave;
        data.inventoriesDicioData = InventoryManager.Instance.ItemDatabase;

        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(SavePath, json);
        Debug.Log($"Jogo salvo em: {SavePath}");
    }

    public static void Load()
    {
        if (!File.Exists(SavePath))
        {
            Debug.LogWarning("Nenhum arquivo de save encontrado!");
        }

        string json = File.ReadAllText(SavePath);
        SaveData data = JsonConvert.DeserializeObject<SaveData>(json);

        //Load do Player
        foreach (var key in data.playerDicioData.Keys)
        {
            PlayerManager.Instance.PlayerDataSave[key] = PlayerManager.Instance.LoadPlayer(key);
        }

        //Load dos intens
        foreach (var key in data.inventoriesDicioData.Keys)
        {
            InventoryManager.Instance.ItemDatabase[key] = InventoryManager.Instance.LoadInventory(key);
        }
        Debug.Log("Save carregado com sucesso!");

    }

    public static void DeleteSave()
    {
        if (File.Exists(SavePath))
            File.Delete(SavePath);
    }
}