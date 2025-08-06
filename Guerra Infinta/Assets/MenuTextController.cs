using UnityEngine;
using UnityEngine.UI;

public class MenuTextController : MonoBehaviour
{

    [SerializeField]
    private DialogueSequenceData menuText;
    private DialogueManager dialogueManager;
    public Text text;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //dialogueManager.StartMenuText(menuText, text);
    }
}
