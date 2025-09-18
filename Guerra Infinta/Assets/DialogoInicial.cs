using System.Collections;
using UnityEngine;

public class DialogoInicial : MonoBehaviour
{
    [Header("Black Screen")]
    [SerializeField] private GameObject screen;
    BlackScreen blackScreen;

    [Header("Dicionário e GameManager-Save")]
    [SerializeField] private string dictionaryKey;
    GameManager gameManager;

    [Header("Diálogo")]
    [SerializeField] private DialogueSequenceData dialogueSequenceStartGame;
    DialogueManager dialogueManager;
    private bool dialogueIsOn;

    void Start()
    {
        gameManager = gameManager = GameObject.Find("SaveSystem").GetComponent<GameManager>();
        dialogueManager = FindAnyObjectByType<DialogueManager>();
        dialogueIsOn = false;
    }

    void Update()
    {
        if (!gameManager.GetDialogueValue(dictionaryKey))
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
        blackScreen = GameObject.Find("BlackScreen").GetComponent<BlackScreen>();
        if (!dialogueIsOn)
        {
            PauseController.SetPause(true);
            dialogueManager.StartDialogue(dialogueSequenceStartGame);
            dialogueIsOn = true;
        }
        else if (dialogueIsOn && !dialogueManager.dialogue)
        {
            blackScreen.StartAnimatorBS();
            gameManager.SaveDialogue(dictionaryKey, true);
        }
    }
}
