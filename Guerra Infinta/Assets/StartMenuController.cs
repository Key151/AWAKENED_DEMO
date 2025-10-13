using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    private string mainMenuSong = "MainMenu";
    private string enterMenu = "Enter";
    private string backMenu = "Back";
    private string LoadGame = "Load";
    public string Scene = "Scene1 1";
    public GameObject menu;
    public GameObject controls;
    LanguageManager languageManager;

    void Start()
    {
        languageManager = GameObject.Find("LanguageManager").GetComponent<LanguageManager>();
        AudioManager.Instance.PlayBGM(mainMenuSong);
        menu.SetActive(true);
    }

    public void StartButton()
    {
        AudioManager.Instance.PlaySFX(enterMenu);
        AudioManager.Instance.StopBGM();
        SceneManager.LoadScene(Scene);
    }

    public void LoadButton()
    {
        AudioManager.Instance.PlaySFX(LoadGame);
        SceneManager.LoadScene(GameManager.Load());
        //try
        //{
        //    AudioManager.Instance.PlaySFX(enterMenu);
        //    SceneManager.LoadScene(GameManager.Load());
        //}
        //catch
        //{
        //    Debug.LogWarning("Erro para carregar!");
        //}
    }

    public void ExitButton()
    {
        AudioManager.Instance.PlaySFX(backMenu);
        Application.Quit();
    }

    public void OpenControls()
    {
        AudioManager.Instance.PlaySFX(enterMenu);
        menu.SetActive(false);
        controls.SetActive(true);
    }

    public void OpenMenu()
    {
        AudioManager.Instance.PlaySFX(backMenu);
        controls.SetActive(false);
        menu.SetActive(true);
    }
    public void ChangePTBR()
    {
        AudioManager.Instance.PlaySFX(enterMenu);
        languageManager.ChangePtBr();
    }
    public void ChangeENG()
    {
        AudioManager.Instance.PlaySFX(enterMenu);
        languageManager.ChangeEng();
    }

}
