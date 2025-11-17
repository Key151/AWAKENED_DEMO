using Newtonsoft.Json;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{
    private static string SavePath => Path.Combine(Application.persistentDataPath, "save.json");
    public static void Save()
    {
        //Save do que precisa
        PlayerManager.Instance.SavePosition();
        SaveData.Data.currentLanguageSave = LanguageManager.Instance.GetLanguage();
        SaveData.Data.playerDicioData = PlayerManager.Instance.PlayerDataSave;
        SaveData.Data.inventoriesDicioData = InventoryManager.Instance.ItemDatabase;
        SaveData.Data.currentSceneName = SceneManager.GetActiveScene().name;
        SaveData.Data.dataDialog = SaveDialogueManager.CopyDialogue();
        SaveData.Data.defeatedEnemiesSave = EnemyController.Instance.SetDefeatedEnemies();
        SaveData.Data.gameStateDicioSave = GameStateController.Instance.SetGameStateDicio();

        var settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        string json = JsonConvert.SerializeObject(SaveData.Data, Formatting.Indented, settings);
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
        SaveData.Data = JsonConvert.DeserializeObject<SaveData>(json);

        //Load do Player
        foreach (var key in SaveData.Data.playerDicioData.Keys)
        {
            PlayerManager.Instance.PlayerDataSave[key] = SaveData.Data.playerDicioData[key];
        }

        //Load dos itens
        foreach (var key in SaveData.Data.inventoriesDicioData.Keys)
        {
            InventoryManager.Instance.ItemDatabase[key] = SaveData.Data.inventoriesDicioData[key];
            Debug.Log("DEBUG DOS ITENS: " + SaveData.Data.inventoriesDicioData[key]);
        }

        //Load dos dialogos
        SaveDialogueManager.PasteDialogue(SaveData.Data.dataDialog);

        //Load dos inimigos
        EnemyController.Instance.GetDefeatedEnemies(SaveData.Data.defeatedEnemiesSave);

        //Load do status do jogo
        GameStateController.Instance.GetGameStateDicio(SaveData.Data.gameStateDicioSave);

        //Load da lingua
        LanguageManager.Instance.SetLanguage(SaveData.Data.currentLanguageSave);


        Debug.Log("Save carregado com sucesso!");
        return SaveData.Data.currentSceneName; 

    }

    public static void DeleteSave()
    {
        if (File.Exists(SavePath))
            File.Delete(SavePath);
    }
}