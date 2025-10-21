using UnityEngine;
using UnityEngine.UI;

public class MenuTextController : MonoBehaviour
{

    [SerializeField] private DialogueLineData menuText;
    [SerializeField] private Text text;
    LanguageManager languageManager;

    private Language lastLanguage;
    private string enterMenu = "Enter";

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
        AudioManager.Instance.PlaySFX(enterMenu, true);
        languageManager.ChangePtBr();
    }
    public void ChangeENG()
    {
        AudioManager.Instance.PlaySFX(enterMenu, true);
        languageManager.ChangeEng();
    }
}
