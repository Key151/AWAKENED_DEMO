using UnityEngine;

public class LanguageManager : MonoBehaviour
{

    private Language currentLanguage;
    void Awake()
    {
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
