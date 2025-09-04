using UnityEngine;

public class DialogoInicial : MonoBehaviour
{
    [SerializeField] private GameObject screen;
    DialogueManager dialogueManager;
    BlackScreen blackScreen;

    
    [SerializeField] private DialogueSequenceData dialogueSequenceStartGame;

    //[SerializeField] private GameObject blackScreen;
    private bool startGame;

    void Start()
    {
        screen.SetActive(true);
        blackScreen = GameObject.Find("BlackScreen").GetComponent<BlackScreen>();
        dialogueManager = FindAnyObjectByType<DialogueManager>();
        startGame = true;
    }

    void Update()
    {
        if (startGame){
            PauseController.SetPause(true);
            dialogueManager.StartDialogue(dialogueSequenceStartGame);
            startGame = false;
        }
        if(dialogueManager.dialogue == false)
        {
            blackScreen.StartAnimatorBS();
        }
    }
}
