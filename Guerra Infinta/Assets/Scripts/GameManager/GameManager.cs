using Newtonsoft.Json;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    private static string SavePath => Path.Combine(Application.persistentDataPath, "save.json");

    public static void Save()
    {
        //Save do que precisa
        SaveData.Data.playerDicioData = PlayerManager.Instance.PlayerDataSave;
        SaveData.Data.inventoriesDicioData = InventoryManager.Instance.ItemDatabase;
        SaveData.Data.currentSceneName = SceneManager.GetActiveScene().name;

        string json = JsonConvert.SerializeObject(SaveData.Data, Formatting.Indented);
        File.WriteAllText(SavePath, json);
        Debug.Log($"Jogo salvo em: {SavePath}");
    }

    public static string Load()
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
        return data.currentSceneName; 

    }

    public static void DeleteSave()
    {
        if (File.Exists(SavePath))
            File.Delete(SavePath);
    }
}