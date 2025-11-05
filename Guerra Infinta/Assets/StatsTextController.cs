using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsTextController : MonoBehaviour
{

    [Header("Menu Text")]
    [SerializeField] private DialogueLineData menuTextLife;
    [SerializeField] private DialogueLineData menuTextDamage;
    [SerializeField] private DialogueLineData menuTextSpeed;

    [Header("Text Mesh Pro")]
    [SerializeField] private TextMeshProUGUI textProLife;
    [SerializeField] private TextMeshProUGUI textProDamage;
    [SerializeField] private TextMeshProUGUI textProSpeed;

    [Header("Unit")]
    [SerializeField] private Unit unit;

    LanguageManager languageManager;

    private Language lastLanguage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        languageManager = LanguageManager.Instance;

        textProLife.text = menuTextLife.GetText(languageManager.GetLanguage()) + unit.CurrentHP + "/" + unit.MaxHP;
        textProDamage.text = menuTextDamage.GetText(languageManager.GetLanguage()) + unit.Damage;
        textProSpeed.text = menuTextSpeed.GetText(languageManager.GetLanguage()) + unit.Spd;
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
            textProLife.text = menuTextLife.GetText(languageManager.GetLanguage()) + unit.CurrentHP + "/" + unit.MaxHP;
            textProDamage.text = menuTextDamage.GetText(languageManager.GetLanguage()) + unit.Damage;
            textProSpeed.text = menuTextSpeed.GetText(languageManager.GetLanguage()) + unit.Spd;
        }

    }
}
