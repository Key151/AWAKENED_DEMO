using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private Dictionary<string, PlayerData> playerDicio = new Dictionary<string, PlayerData>();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SavePlayer(PlayerData player)
    {
        //Debug.Log($"[SAVE] {player.playerId} HP={player.hp}");
        playerDicio[player.playerId] = player;
    }

    public PlayerData LoadPlayer(string playerId)
    {
        //Debug.Log($"[LOAD] Tentando carregar {playerId}");

        if (playerDicio.TryGetValue(playerId, out PlayerData data))
        {
            //Debug.Log($"[LOAD] Achei {data.playerId} HP={data.hp}");
            return data;
        }
        //Debug.Log("[LOAD] Nao encontrado!");
        return null;
    }
}
