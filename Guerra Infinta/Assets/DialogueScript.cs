using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    [Header("Dicionário e GameManager-Save")]
    [SerializeField] private string dictionaryKey;
    GameManager gameManager;

    [Header("Diálogo")]
    [SerializeField] private DialogueSequenceData dialogueSequenceStartGame;
    DialogueManager dialogueManager;

    private bool dialogueIsOn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = gameManager = GameObject.Find("SaveSystem").GetComponent<GameManager>();
        dialogueManager = FindAnyObjectByType<DialogueManager>();
        dialogueIsOn = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gameManager.GetDialogueValue(dictionaryKey))
        {
            StartDialogue();
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
            gameManager.SaveDialogue(dictionaryKey, true);
        }
    }

}
