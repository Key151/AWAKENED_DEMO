using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public string Scene = "Scene1 1";
    public GameObject menu;
    public GameObject controls;

    void Start()
    {
        menu.SetActive(true);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(Scene);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void OpenControls()
    {
        menu.SetActive(false);
        controls.SetActive(true);
    }

    public void OpenMenu()
    {
        controls.SetActive(false);
        menu.SetActive(true);
    }
}
