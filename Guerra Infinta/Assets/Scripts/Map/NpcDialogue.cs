using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NpcDialogue : MonoBehaviour
{

    [Header("Diaogo")]
    [SerializeField] private DialogueSequenceData dialogueScene;
    private DialogueManager dialogueManager;

    [Header("Variaeis")]
    [SerializeField] private GameObject clickToSpeak;
    private bool readyToSpeak;

    [Header("Batalha")]
    [SerializeField] private StartBattleController startBattleController;

    //void Start()    
    //{
    //    dialogueManager = FindAnyObjectByType<DialogueManager>();
    //    DisactiveClickToSpeak();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    StartCoroutine(EsperarDialogoETrocarCena());
    //}

    IEnumerator EsperarDialogoETrocarCena()
    {
        if (Input.GetButtonDown("Fire1") && readyToSpeak)
        {
            PauseController.SetPause(true);
            dialogueManager.StartDialogue(dialogueScene);
            DisactiveClickToSpeak();
            readyToSpeak = false;

            yield return new WaitUntil(() => dialogueManager.dialogue == false); // Aqui a corrotina fica parada atÅEque a condicao seja verdadeira

            startBattleController.StartBattle();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Menino"))
        {
            readyToSpeak = true;
            ActiveClickToSpeak();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Menino"))
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
