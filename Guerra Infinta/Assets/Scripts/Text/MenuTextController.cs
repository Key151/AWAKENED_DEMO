using UnityEngine;
using UnityEngine.UI;

public class MenuTextController : MonoBehaviour
{

    [SerializeField] private DialogueLineData menuText;
    [SerializeField] private Text text;
    LanguageManager languageManager;

    private Language lastLanguage;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        languageManager = GameObject.Find("LanguageManager").GetComponent<LanguageManager>();
        text.text = menuText.GetText(languageManager.GetLanguage());
        lastLanguage = languageManager.GetLanguage();
    }

    // Update is called once per frame
    void Update()
    {
        if (lastLanguage == languageManager.GetLanguage())
        {
            return;
        }
        else
        {
            lastLanguage = languageManager.GetLanguage();
            text.text = menuText.GetText(languageManager.GetLanguage());
        }
            
    }

    public void ChangePTBR()
    {
        languageManager.ChangePtBr();
    }
    public void ChangeENG()
    {
        languageManager.ChangeEng();
    }
}
