using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    [Header("UI")]
    public Image iconImage;
    public Text speakerText;
    public Text dialogueText;
    public GameObject dialoguePanel;
    public bool dialogue;

    private DialogueSequenceData currentSequence;
    LanguageManager languageManager;
    private int currentIndex;
    private string enterMenu = "Enter";

    public void Start()
    {
        languageManager = GameObject.Find("LanguageManager").GetComponent<LanguageManager>();
    }

    public void StartDialogue(DialogueSequenceData sequence)
    {
        dialogue = true;
        currentSequence = sequence;
        currentIndex = 0;
        dialoguePanel.SetActive(true);
        PauseController.SetPause(true);
        ShowLine();
    }

    public void NextLine()
    {
        AudioManager.Instance.PlaySFX(enterMenu);
        currentIndex++;
        //Debug.Log($"Proxima linha, a linha atual: {currentIndex}");
        if (currentIndex >= currentSequence.dialogueLines.Count)
        {
            PauseController.SetPause(false);
            EndDialogue();
            return;
        }
        else
        {
            ShowLine();
        }
        
    }

    private void ShowLine()
    {
        var line = currentSequence.dialogueLines[currentIndex];
        Color cor = iconImage.color;
        if (line.Icon != null)
        {
            cor.a = 1f;
            iconImage.color = cor;
            iconImage.sprite = line.Icon;
        }
        else
        {
            cor.a = 0f;
            iconImage.color = cor;
        }

        speakerText.text = line.SpeakerName;
        dialogueText.text = line.GetText(languageManager.GetLanguage());
    }

    private void EndDialogue()
    {
        dialogue = false;
        dialoguePanel.SetActive(false);
    }
}