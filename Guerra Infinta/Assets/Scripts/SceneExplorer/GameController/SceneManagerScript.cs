using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonExplorer : MonoBehaviour
{
    private string mainMenuSong = "MainMenu";
    private string enterMenu = "Enter";
    private string backMenu = "Back";
    public void LoadScene(string sceneName)
    {
        AudioManager.Instance.PlaySFX(enterMenu);
        SceneManager.LoadScene(sceneName);
    }

    public void SaveButton()
    {
        AudioManager.Instance.PlaySFX(enterMenu);
        GameManager.Save();
    }
}