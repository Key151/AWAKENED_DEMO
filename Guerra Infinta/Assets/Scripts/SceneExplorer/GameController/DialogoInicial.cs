using System.Collections;
using UnityEngine;

public class DialogoInicial : MonoBehaviour
{
    [Header("Black Screen")]
    [SerializeField] private GameObject screen;
    BlackScreen blackScreen;

    [Header("Dicionaio e GameManager-Save")]
    [SerializeField] private string dictionaryKey;
    SaveDialogueManager saveDialogueManager;

    [Header("Diaogo")]
    [SerializeField] private DialogueSequenceData dialogueSequenceStartGame;
    DialogueManager dialogueManager;
    private bool dialogueIsOn;

    void Start()
    {
        saveDialogueManager = GameObject.Find("SaveDialogueManager").GetComponent<SaveDialogueManager>();
        dialogueManager = FindAnyObjectByType<DialogueManager>();
        dialogueIsOn = false;
    }

    void Update()
    {
        if (!saveDialogueManager.GetDialogueValue(dictionaryKey))
        {
            StartDialogue();
        }
        else
        {
            screen.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

    public void StartDialogue()
    {
        screen.SetActive(true);
        blackScreen = screen.GetComponent<BlackScreen>();
        if (!dialogueIsOn)
        {
            PauseController.SetPause(true);
            dialogueManager.StartDialogue(dialogueSequenceStartGame);
            dialogueIsOn = true;
        }
        else if (dialogueIsOn && !dialogueManager.dialogue)
        {
            blackScreen.StartFadeIn();
            saveDialogueManager.SaveDialogue(dictionaryKey, true);
            StateObjectsController.Instance.ChangeStateObjects("StartGame");
        }
    }
}
