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

    private bool isColliding;

    [Header("ChangeGameState (Deixar vazio se não quiser mudar o status do jogo)")]
    [SerializeField] private string state;

    void Start()
    {
        saveDialogueManager = SaveDialogueManager.Instance;
        dialogueManager = FindAnyObjectByType<DialogueManager>();
        dialogueIsOn = false;
        isColliding = false;

        if (string.IsNullOrEmpty(state))
        {
            state = null;
        }
    }
    void Update()
    {
        if (!saveDialogueManager.GetDialogueValue(dictionaryKey))
        {
            if (isColliding)
            {
                StartDialogue();
            }
        }
        else
        {
            StateObjectsController.Instance.ChangeStateObjects(state);
            this.gameObject.SetActive(false);
        }
    }


    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Menino"))
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Menino"))
        {
            isColliding = false;
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
