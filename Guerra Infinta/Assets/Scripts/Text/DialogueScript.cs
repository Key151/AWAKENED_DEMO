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

    [Header("ChangeGameState (Colocar somente se for mudar o status do jogo)")]
    [SerializeField] private string state;

    [Header("Black Screen (Colocar somente se for usar a tela preta)")]
    [SerializeField] private GameObject screen;
    BlackScreen blackScreen;

    [Header("Position (Usar se quiser mudar a posição do personagem")]
    [SerializeField] private GameObject position;
    void Start()
    {
        saveDialogueManager = SaveDialogueManager.Instance;
        dialogueManager = FindAnyObjectByType<DialogueManager>();
        dialogueIsOn = false;

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
            if(screen != null)
            {
                screen.SetActive(true);
                blackScreen = screen.GetComponent<BlackScreen>();
                blackScreen.StartFadeOut();
            }
            dialogueIsOn = true;
            dialogueManager.StartDialogue(dialogueSequenceStartGame);
        }
        else if (dialogueIsOn && !dialogueManager.dialogue)
        {
            if (position != null)
            {
                GameObject marco = GameObject.FindWithTag("Menino");
                GameObject Rafael = GameObject.FindWithTag("Menina");
                marco.GetComponent<PlayerMovement>().ResetPosotionHistory();
                Rafael.transform.position = position.transform.position;
                marco.transform.position = position.transform.position;
                
            }
            if (screen != null)
            {
                blackScreen.StartFadeIn();
            }
            saveDialogueManager.SaveDialogue(dictionaryKey, true);
            StateObjectsController.Instance.ChangeStateObjects(state);
        }
    }

}
