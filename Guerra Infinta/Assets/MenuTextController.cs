using UnityEngine;
using UnityEngine.UI;

public class MenuTextController : MonoBehaviour
{

    [SerializeField] private DialogueLineData menuText;
    [SerializeField] private Text text;
    LanguageManager languageManager;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        languageManager = GameObject.Find("LanguageManager").GetComponent<LanguageManager>();
        text.text = menuText.GetText(languageManager.GetLanguage());
    }

    // Update is called once per frame
    void Update()
    {
        text.text = menuText.GetText(languageManager.GetLanguage());
    }
}
