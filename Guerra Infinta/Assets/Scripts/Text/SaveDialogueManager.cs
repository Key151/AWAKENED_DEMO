using System.Collections.Generic;
using UnityEngine;

public class SaveDialogueManager : MonoBehaviour
{
    public static SaveDialogueManager Instance { get; private set; }

    private static Dictionary<string, bool> dialogueDicio = new Dictionary<string, bool>();

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

    public void CreatDialogue()
    {
        dialogueDicio.Add("dialogue_Inicial", false);
        dialogueDicio.Add("dialogue_1", false);
        dialogueDicio.Add("dialogue_Tutorial", false);
    }
    public static Dictionary<string, bool> CopyDialogue()
    {
        return dialogueDicio;
    }

    public static void PasteDialogue(Dictionary<string, bool> dialogue)
    {
        dialogueDicio = dialogue;
    }
}
