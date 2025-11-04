using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager Instance { get; private set; }
    private Language currentLanguage;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        currentLanguage = Language.PtBr;
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

    public Language GetLanguage()
    {
        return currentLanguage;
    }

}
