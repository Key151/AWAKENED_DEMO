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
        dialogueDicio.Clear();
        dialogueDicio.Add("dialogue_Inicial", false);
        dialogueDicio.Add("dialogue_Tutorial", false);
        dialogueDicio.Add("dialogue_8", false);
        dialogueDicio.Add("dialogue_9", false);
        dialogueDicio.Add("dialogue_10", false);
        dialogueDicio.Add("dialogue_11", false);
        dialogueDicio.Add("dialogue_12", false);
        dialogueDicio.Add("dialogue_13", false);
        dialogueDicio.Add("dialogue_14", false);
        dialogueDicio.Add("dialogue_15", false);
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
