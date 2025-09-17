using System.ComponentModel;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class DialogueScript : MonoBehaviour
{

    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private DialogueSequenceData dialogueSequenceStartGame;
    private static bool hasDialoguePlayed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueManager = FindAnyObjectByType<DialogueManager>();
        hasDialoguePlayed = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasDialoguePlayed)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PauseController.SetPause(true);
                dialogueManager.StartDialogue(dialogueSequenceStartGame);
                hasDialoguePlayed = true;
            }
        }
    }
}
