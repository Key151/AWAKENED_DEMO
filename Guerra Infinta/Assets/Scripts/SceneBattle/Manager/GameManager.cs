using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private Dictionary<string, PlayerData> playerDicio = new Dictionary<string, PlayerData>();

    private Dictionary<string, bool> dialogueDicio = new Dictionary<string, bool>();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        dialogueDicio.Add("dialogue_Inicial", false);
        dialogueDicio.Add("dialogue_1", false);
        DontDestroyOnLoad(gameObject);
    }

    public void savePlayer(PlayerData player)
    {
        //Debug.Log($"[SAVE] {player.playerId} HP={player.hp}");
        playerDicio[player.playerId] = player;
    }

    public PlayerData loadPlayer(string playerId)
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

    public void SaveDialogue(string dialogueKey, bool dialogueValue)
    {
        if (dialogueDicio.ContainsKey(dialogueKey))
        {
            dialogueDicio[dialogueKey] = dialogueValue;
        }
        else return;
    }

    public bool GetDialogueValue(string dialogueKey)
    {
        if (dialogueDicio.ContainsKey(dialogueKey))
        {
            return dialogueDicio[dialogueKey];
        }
        else return false;
    }

}
