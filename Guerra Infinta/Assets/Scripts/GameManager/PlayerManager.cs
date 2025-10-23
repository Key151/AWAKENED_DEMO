using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    public Dictionary<string, PlayerData> PlayerDataSave { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        //DontDestroyOnLoad(gameObject);

        if (PlayerDataSave == null) PlayerDataSave = new Dictionary<string, PlayerData>(); // <- so cria se for a primeira vez
 
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

    public void SavePosition()
    {
        GameObject menino = GameObject.FindWithTag("Menino");
        string nomeMenino = menino.GetComponent<UnitPlayer>().UnitName;
        Vector3 posicaoMenino = menino.transform.position;

        GameObject menina = GameObject.FindWithTag("Menina");
        string nomeMenina = menina.GetComponent<UnitPlayer>().UnitName;

        PlayerDataSave[nomeMenina].playerPosition = posicaoMenino;
        PlayerDataSave[nomeMenino].playerPosition = posicaoMenino;


        Debug.Log($"[LOAD - SavePosition] Achei {PlayerDataSave[nomeMenino].playerId} Position={PlayerDataSave[nomeMenino].playerPosition}");

    }

    public void LoadPosition()
    {
        GameObject menino = GameObject.FindWithTag("Menino");
        string nomeMenino = menino.GetComponent<UnitPlayer>().UnitName;

        GameObject menina = GameObject.FindWithTag("Menina");
        string nomeMenina = menina.GetComponent<UnitPlayer>().UnitName;

        Debug.Log($"[LoadPosition] Achei {PlayerDataSave[nomeMenino].playerId} Position={PlayerDataSave[nomeMenino].playerPosition}");

        if (PlayerDataSave[nomeMenino].playerPosition == Vector3.zero) return;

        else //if (PlayerDataSave.TryGetValue(nomeMenino, out PlayerData data)) //Procura o player com esse ID e armazena em data
        {
            menino.transform.position = PlayerDataSave[nomeMenino].playerPosition;
            menina.transform.position = PlayerDataSave[nomeMenino].playerPosition;
        }
    }
}
