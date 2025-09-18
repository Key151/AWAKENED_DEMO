using System.Collections.Generic;
using UnityEngine;

public class SaveDialogueManager : MonoBehaviour
{

    private Dictionary<string, bool> dialogueDicio = new Dictionary<string, bool>();

    void Awake()
    {
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
    }
}
