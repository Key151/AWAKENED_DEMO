using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    private string mainMenuSong = "MainMenu";
    private string enterMenu = "Enter";
    private string backMenu = "Back";
    public string Scene = "Scene1 1";
    public GameObject menu;
    public GameObject controls;

    void Start()
    {
        audioManager.PlayBGM(mainMenuSong);
        menu.SetActive(true);
    }

    public void StartButton()
    {
        audioManager.PlaySFX(enterMenu);
        SceneManager.LoadScene(Scene);
    }

    public void ExitButton()
    {
        audioManager.PlaySFX(backMenu);
        Application.Quit();
    }

    public void OpenControls()
    {
        audioManager.PlaySFX(enterMenu);
        menu.SetActive(false);
        controls.SetActive(true);
    }

    public void OpenMenu()
    {
        audioManager.PlaySFX(backMenu);
        controls.SetActive(false);
        menu.SetActive(true);
    }
}
