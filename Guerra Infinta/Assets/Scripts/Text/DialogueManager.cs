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

    private DialogueSequenceData currentSequence;
    private int currentIndex;
    private Language currentLanguage = Language.PtBr;

    public void StartDialogue(DialogueSequenceData sequence)
    {
        currentSequence = sequence;
        currentIndex = 0;
        dialoguePanel.SetActive(true);
        FindAnyObjectByType<Player>().speedControl = 0f;
        ShowLine();
    }

    public void NextLine()
    {
        currentIndex++;
        Debug.Log($"Proxima linha, a linha atual: {currentIndex}");
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
        iconImage.sprite = line.Icon;
        speakerText.text = line.SpeakerName;
        dialogueText.text = line.GetText(currentLanguage);
    }

    private void EndDialogue()
    {
        FindAnyObjectByType<Player>().speedControl = 1;
        dialoguePanel.SetActive(false);
    }
    public void SetLanguage(Language language)
    {
        currentLanguage = language;
    }
    public void ChangePtBr()
    {
        currentLanguage = Language.PtBr;
    }

    public void ChangeEng()
    {
        currentLanguage = Language.Eng;
    }
}