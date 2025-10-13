using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    [SerializeField] private UnitPlayerBoy Menino;
    [SerializeField] private UnitPlayerGirl Menina;
    public Dictionary<string, PlayerData> PlayerDataSave { get;private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        PlayerDataSave = new Dictionary<string, PlayerData>();
        PlayerDataSave[Menino.UnitName] = Menino.PlayerData;
        PlayerDataSave[Menina.UnitName] = Menina.PlayerData;

        //SaveData.Data.playerDicioData = PlayerDataSave;
    }   

    public void SavePlayer(PlayerData player)
    {
        //Debug.Log($"[SAVE] {player.playerId} HP={player.hp}");
        PlayerDataSave[player.playerId] = player;
    }

    public PlayerData LoadPlayer(string playerId)
    {
        //Debug.Log($"[LOAD] Tentando carregar {playerId}");

        if (PlayerDataSave.TryGetValue(playerId, out PlayerData data))
        {
            //Debug.Log($"[LOAD] Achei {data.playerId} HP={data.hp}");
            return data;
        }
        //Debug.Log("[LOAD] Nao encontrado!");
        return null;
    }
}
