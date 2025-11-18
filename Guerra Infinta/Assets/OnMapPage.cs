using UnityEngine;

public class OnMapPage : MonoBehaviour
{
    public GameObject mapPT;
    public GameObject mapENG;

    void Update()
    {
        if (LanguageManager.Instance.GetLanguage() == Language.PtBr)
        {
            mapENG.SetActive(false);
            mapPT.SetActive(true);
        }
        else if(LanguageManager.Instance.GetLanguage() == Language.Eng)
        {
            mapPT.SetActive(false);
            mapENG.SetActive(true);
        }

    }
}
