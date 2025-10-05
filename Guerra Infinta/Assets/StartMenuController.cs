using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    private string mainMenuSong = "MainMenu";
    private string enterMenu = "Enter";
    private string backMenu = "Back";
    public string Scene = "Scene1 1";
    public GameObject menu;
    public GameObject controls;

    void Start()
    {
        AudioManager.Instance.PlayBGM(mainMenuSong);
        menu.SetActive(true);
    }

    public void StartButton()
    {
        AudioManager.Instance.PlaySFX(enterMenu);
        AudioManager.Instance.StopBGM();
        SceneManager.LoadScene(Scene);
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
}
