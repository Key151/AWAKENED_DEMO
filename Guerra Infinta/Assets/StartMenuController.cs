using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    private string mainMenuSong = "MainMenu";
    private string enterMenu = "Enter";
    private string backMenu = "Back";
    private string LoadGame = "Load";
    public string Scene = "SceneExplorer";
    public GameObject menu;
    public GameObject controls;
    LanguageManager languageManager;

    [Header("Black Screen")]
    [SerializeField] private GameObject screen;
    BlackScreen blackScreen;

    void Start()
    {
        languageManager = GameObject.Find("LanguageManager").GetComponent<LanguageManager>();
        AudioManager.Instance.PlayBGM(mainMenuSong);
        menu.SetActive(true);
        screen.SetActive(false);
    }

    public void StartButton()
    {
        AudioManager.Instance.PlaySFX(enterMenu, true);
        AudioManager.Instance.StopBGM();
        screen.SetActive(true);
        blackScreen = screen.GetComponent<BlackScreen>();
        blackScreen.StartFadeOut();
    }

    public void LoadButton()
    {
        AudioManager.Instance.PlaySFX(LoadGame, true);
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
        AudioManager.Instance.PlaySFX(backMenu, true);
        Application.Quit();
    }

    public void OpenControls()
    {
        AudioManager.Instance.PlaySFX(enterMenu, true);
        menu.SetActive(false);
        controls.SetActive(true);
    }

    public void OpenMenu()
    {
        AudioManager.Instance.PlaySFX(backMenu, true);
        controls.SetActive(false);
        menu.SetActive(true);
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
