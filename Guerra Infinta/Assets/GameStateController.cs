using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public static GameStateController Instance { get; private set; }

    private static Dictionary<string, bool> gameStateDicio = new Dictionary<string, bool>();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        CreatDialogue();
    }
    public Dictionary<string, bool> SetGameStateDicio()
    {
        return gameStateDicio;
    }

    public void GetGameStateDicio(Dictionary<string, bool> state)
    {
        gameStateDicio = state;
    }

    public void CreatDialogue()
    {
        gameStateDicio.Clear();
        gameStateDicio.Add("StartGame", false);
        gameStateDicio.Add("TutorialBattle", false);
    }

    public void DisableCurrentState()
    {
        if (gameStateDicio == null || gameStateDicio.Count == 0) return;

        foreach( var key in gameStateDicio.Keys.ToList())
        {
            gameStateDicio[key] = false;
        }
    }
    public string GetCurrentState()
    {
        if (gameStateDicio == null || gameStateDicio.Count == 0) return null;

        foreach (var key in gameStateDicio.Keys.ToList())
        {
            if (gameStateDicio[key] == true)
            {
                return key;
            }
        }
        return null;
    }

    public void ChangeCurrentState(string state)
    {
        if (gameStateDicio.ContainsKey(state))
        {
            DisableCurrentState();
            gameStateDicio[state] = true;
        }
        else
        {
            return;
        }
    }
}
