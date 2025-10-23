using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonExplorer : MonoBehaviour
{
    private string ExplorerSong = "Explorer02";
    private string enterMenu = "Enter";
    private string SaveGame = "Save";
    private string backMenu = "Back";

    private void Start()
    {
        PlayerManager.Instance.LoadPosition();
        AudioManager.Instance.PlayBGM(ExplorerSong);   
    }
    public void LoadScene(string sceneName)
    {
        AudioManager.Instance.PlaySFX(enterMenu, true);
        SceneManager.LoadScene(sceneName);
    }

    public void SaveButton()
    {
        AudioManager.Instance.PlaySFX(SaveGame, true);
        GameManager.Save();
    }
}