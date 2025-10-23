using System.Collections.Generic;
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
        DontDestroyOnLoad(gameObject);

        PlayerDataSave = new Dictionary<string, PlayerData>();
        PlayerDataSave = SaveData.Data.playerDicioData;
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
    }

    public void LoadPosition()
    {
        GameObject menino = GameObject.FindWithTag("Menino");
        string nomeMenino = menino.GetComponent<UnitPlayer>().UnitName;

        GameObject menina = GameObject.FindWithTag("Menina");

        if (PlayerDataSave[nomeMenino].playerPosition == Vector3.zero)
        {
            PlayerDataSave[nomeMenino].playerPosition = menino.transform.position;
        }

        else //if (PlayerDataSave.TryGetValue(nomeMenino, out PlayerData data)) //Procura o player com esse ID e armazena em data
        {
            Debug.Log($"[LOAD] Achei {PlayerDataSave[nomeMenino].playerId} Position={PlayerDataSave[nomeMenino].playerPosition}");
            menino.transform.position = PlayerDataSave[nomeMenino].playerPosition;
            menina.transform.position = PlayerDataSave[nomeMenino].playerPosition;
        }
    }
}
