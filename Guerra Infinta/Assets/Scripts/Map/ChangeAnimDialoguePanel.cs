using UnityEngine;

public class ChangeAnimDialoguePanel : MonoBehaviour
{
    private Animator dialoguePanel_UI;
    public bool closePanel;
    void Start()
    {
        dialoguePanel_UI = GetComponent<Animator>();
        closePanel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (closePanel == true)
        {
            dialoguePanel_UI.Play("DialoguePanel_Close");
        }
    }
}
