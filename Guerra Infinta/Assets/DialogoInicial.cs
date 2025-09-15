using System.Collections;
using UnityEngine;

public class DialogoInicial : MonoBehaviour
{
    [SerializeField] private GameObject screen;
    DialogueManager dialogueManager;
    BlackScreen blackScreen;

    
    [SerializeField] private DialogueSequenceData dialogueSequenceStartGame;
    GameManager gameManager;

    //[SerializeField] private GameObject blackScreen;

    void Start()
    {
        gameManager = GameObject.Find("SaveSystem").GetComponent<GameManager>();
        dialogueManager = FindAnyObjectByType<DialogueManager>();
    }

    void Update()
    {
        if (!gameManager.FirstSceneStatusNeverPlayAgain())
        {
            screen.SetActive(true);
            blackScreen = GameObject.Find("BlackScreen").GetComponent<BlackScreen>();
            if (gameManager.FirstSceneStatusGameStarted())
            {
                PauseController.SetPause(true);
                gameManager.IsPlayinfFirstScene();
                dialogueManager.StartDialogue(dialogueSequenceStartGame);
            }
            else if(gameManager.FirstSceneStatusEnded())
            {
                blackScreen.StartAnimatorBS();
            }
        }
    }
}
