using UnityEngine;

public class TutorialDialogue : MonoBehaviour
{

    [Header("Dicionaio e GameManager-Save")]
    [SerializeField] private string dictionaryKey;
    SaveDialogueManager saveDialogueManager;

    [Header("Diaogo")]
    [SerializeField] private DialogueSequenceData dialogueSequenceStartGame;
    DialogueManager dialogueManager;
    private bool dialogueIsOn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saveDialogueManager = GameObject.Find("SaveDialogueManager").GetComponent<SaveDialogueManager>();
        dialogueManager = FindAnyObjectByType<DialogueManager>();
        dialogueIsOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!saveDialogueManager.GetDialogueValue(dictionaryKey))
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
            saveDialogueManager.SaveDialogue(dictionaryKey, true);
        }
    }

}
