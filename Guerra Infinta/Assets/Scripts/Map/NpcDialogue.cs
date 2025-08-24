using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class NpcDialogue : MonoBehaviour
{
    //public string[] dialogueNpc;
    //public int dialogueIndex;
    //public string npcName;

    public GameObject clickToSpeak;
    //public GameObject dialoguePanel;
    //public Text dialogueText;

    //public Text nameNpc;
    //public Image imageNpc;
    //public Sprite spriteNpc;

    [SerializeField]
    private DialogueSequenceData dialogueScene;
    private DialogueManager dialogueManager;
    private bool readyToSpeak;
    void Start()    
    {
        dialogueManager = FindAnyObjectByType<DialogueManager>();
        DisactiveClickToSpeak();
        //dialoguePanel_UI = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && readyToSpeak)
        {
            PauseController.SetPause(true);
            //FindAnyObjectByType<Player>().speedControl = 0f;
            dialogueManager.StartDialogue(dialogueScene);
            DisactiveClickToSpeak();
            readyToSpeak = false;
        }
    }
    //void NextDialogue()
    //{
    //    dialogueIndex++;

    //    if (dialogueIndex < dialogueNpc.Length)
    //    {
    //        StartCoroutine(ShowDialogue());
    //    }
    //    else
    //    {
    //        dialoguePanel.SetActive(false);
    //        startDialogue = false;
    //        dialogueIndex = 0;
    //        FindAnyObjectByType<Player>().speedControl = 1;
    //        //FindAnyObjectByType<ChangeAnimDialoguePanel>().closePanel = true;
    //    }
    //}
    //void StartDialogue()
    //{
    //    nameNpc.text = npcName;
    //    imageNpc.sprite = spriteNpc;
    //    startDialogue = true;
    //    dialogueIndex = 0;
    //    //FindAnyObjectByType<ChangeAnimDialoguePanel>().closePanel = false;
    //    dialoguePanel.SetActive(true);
    //    StartCoroutine(ShowDialogue());
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            readyToSpeak = true;
            ActiveClickToSpeak();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            readyToSpeak = false;
            DisactiveClickToSpeak();
        }
    }
    private void ActiveClickToSpeak()
    {
        clickToSpeak.SetActive(true);
    }
    private void DisactiveClickToSpeak()
    {
        clickToSpeak.SetActive(false);
    }
}
