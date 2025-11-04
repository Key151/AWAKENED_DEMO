using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    [Header("Dicionaio e GameManager-Save")]
    [SerializeField] private string dictionaryKey;
    SaveDialogueManager saveDialogueManager;

    [Header("Dialogo")]
    [SerializeField] private DialogueSequenceData dialogueSequenceStartGame;
    DialogueManager dialogueManager;

    private bool dialogueIsOn;

    void Start()
    {
        saveDialogueManager = SaveDialogueManager.Instance;
        dialogueManager = FindAnyObjectByType<DialogueManager>();
        dialogueIsOn = false;

        if (saveDialogueManager != null && saveDialogueManager.GetDialogueValue(dictionaryKey))
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!saveDialogueManager.GetDialogueValue(dictionaryKey))
        {
            if (collision.CompareTag("Menino"))
            {
                StartDialogue();
                this.gameObject.SetActive(false);
            }
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    public void StartDialogue()
    {
        if (!dialogueIsOn)
        {
            PauseController.SetPause(true);
            dialogueManager.StartDialogue(dialogueSequenceStartGame);
            dialogueIsOn = true;
        }
        else if (dialogueIsOn && !dialogueManager.dialogue)
        {
            saveDialogueManager.SaveDialogue(dictionaryKey, true);
        }
    }

}
