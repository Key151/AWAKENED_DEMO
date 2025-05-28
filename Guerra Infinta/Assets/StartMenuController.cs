using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public string Scene = "Scene1 1";

    public void StartButton()
    {
        SceneManager.LoadScene(Scene);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
