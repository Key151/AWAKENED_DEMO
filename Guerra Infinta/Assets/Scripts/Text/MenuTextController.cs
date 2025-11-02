using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuTextController : MonoBehaviour
{

    [SerializeField] private DialogueLineData menuText;
    [SerializeField] private Text text;
    [SerializeField] private TextMeshProUGUI textPro;
    [SerializeField] private bool usingTMP = false;
    LanguageManager languageManager;

    private Language lastLanguage;
    private string enterMenu = "Enter";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        languageManager = GameObject.FindWithTag("LanguageManager").GetComponent<LanguageManager>();
        if (!usingTMP)
        {
            text.text = menuText.GetText(languageManager.GetLanguage());
        }
        else
        {
            textPro.text = menuText.GetText(languageManager.GetLanguage());
        }
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
            if (!usingTMP)
            {
                text.text = menuText.GetText(languageManager.GetLanguage());
            }
            else
            {
                textPro.text = menuText.GetText(languageManager.GetLanguage());
            }
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
