using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private Dictionary<string, PlayerData> playerDicio = new Dictionary<string, PlayerData>();

    private enum FirstDialogueState
    {
        GameStarted,
        DialoguePlaying,
        DialogueEnded,
        NeverPlayAgain
    }

    private FirstDialogueState dialogueState;

    private bool firstScene;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        dialogueState = FirstDialogueState.GameStarted;
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


    // Controlador do dialogo inicial
    public bool FirstSceneStatusEnded()
    {
        return dialogueState == FirstDialogueState.DialogueEnded;
    }

    public bool FirstSceneStatusPlaying()
    {
        return dialogueState == FirstDialogueState.DialoguePlaying;
    }

    public bool FirstSceneStatusGameStarted()
    {
        return dialogueState == FirstDialogueState.GameStarted;
    }

    public bool FirstSceneStatusNeverPlayAgain()
    {
        return dialogueState == FirstDialogueState.NeverPlayAgain;
    }

    public void EndFirstScene()
    {
        dialogueState = FirstDialogueState.DialogueEnded;
    }

    public void IsPlayinfFirstScene()
    {
        dialogueState = FirstDialogueState.DialoguePlaying;
    }

    public void NeverPlayFirstScene()
    {
        dialogueState = FirstDialogueState.NeverPlayAgain;
    }

}
