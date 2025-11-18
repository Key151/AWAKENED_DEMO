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
    public GameObject instruction;
    public GameObject instruction_ing;
    public GameObject credits;
    LanguageManager languageManager;

    [Header("Black Screen")]
    [SerializeField] private GameObject screen;
    BlackScreen blackScreen;

    void Start()
    {
        languageManager = LanguageManager.Instance;
        AudioManager.Instance.PlayBGM(mainMenuSong);
        menu.SetActive(true);
        screen.SetActive(false);
    }

    public void StartButton()
    {
        SaveSystemDestroy.Instance.DestroySaveSystem();
        //Instantiate(saveSystem, new Vector3(0, 0, 0), Quaternion.identity);
        AudioManager.Instance.PlaySFX(enterMenu, true);
        AudioManager.Instance.StopBGM();
        screen.SetActive(true);
        blackScreen = screen.GetComponent<BlackScreen>();
        blackScreen.StartFadeOut();
    }

    public void LoadButton()
    {
        AudioManager.Instance.PlaySFX(LoadGame, true);
        if(GameManager.Load() != null)
        {
            SceneManager.LoadScene(GameManager.Load());
            AudioManager.Instance.StopBGM();
        }
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

    public void OpenInstruction()
    {
        AudioManager.Instance.PlaySFX(enterMenu, true);
        controls.SetActive(false);
        if (LanguageManager.Instance.GetLanguage() == Language.PtBr) instruction.SetActive(true);
        else instruction_ing.SetActive(true);
        instruction.SetActive(true);
    }

    public void OpenCredits()
    {
        AudioManager.Instance.PlaySFX(enterMenu, true);
        controls.SetActive(false);
        credits.SetActive(true);
    }

    public void BackControls()
    {
        AudioManager.Instance.PlaySFX(backMenu, true);
        credits.SetActive(false);
        instruction.SetActive(false);
        instruction_ing.SetActive(false);
        controls.SetActive(true);
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
