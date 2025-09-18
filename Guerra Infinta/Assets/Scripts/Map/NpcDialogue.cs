using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NpcDialogue : MonoBehaviour
{

    [Header("Diálogo")]
    [SerializeField] private DialogueSequenceData dialogueScene;
    private DialogueManager dialogueManager;

    [Header("Variáveis")]
    [SerializeField] string scene;
    [SerializeField] private GameObject clickToSpeak;
    private bool readyToSpeak;


    void Start()    
    {
        dialogueManager = FindAnyObjectByType<DialogueManager>();
        DisactiveClickToSpeak();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(EsperarDialogoETrocarCena());
    }

    IEnumerator EsperarDialogoETrocarCena()
    {
        if (Input.GetButtonDown("Fire1") && readyToSpeak)
        {
            PauseController.SetPause(true);
            dialogueManager.StartDialogue(dialogueScene);
            DisactiveClickToSpeak();
            readyToSpeak = false;

            yield return new WaitUntil(() => dialogueManager.dialogue == false); // Aqui a corrotina fica parada até que a condição seja verdadeira

            SceneManager.LoadScene(scene);
        }
    }

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
