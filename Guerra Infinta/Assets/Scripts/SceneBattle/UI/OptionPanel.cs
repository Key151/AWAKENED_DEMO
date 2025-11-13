using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionPanel : MonoBehaviour
{
    [Header("Scene")]
    public string sceneExplorer;
    public string sceneMenu;

    [Header("Music")]
    private string enterMenu = "Enter";
    private string backMenu = "Back";
    private string LoadGame = "Load";

    [Header("Classes")]
    [SerializeField] private BattleSystem battleSystem;
    [SerializeField] private VerificateButtonUI verificateButtonUI;
    [SerializeField] private EnemyButtonController enemyButtonController;
    DialogueManager dialogueManager;

    [Header("Diaogo")]
    [SerializeField] private DialogueSequenceData dialogueSequenceStartGame;

    public void OnAttackButton()
    {
        if (PauseController.IsGamePaused) return;
        AudioManager.Instance.PlaySFX(enterMenu, true);
        verificateButtonUI.DisactivateButtons();
        enemyButtonController.SelectEnemyButtonAtack();
        verificateButtonUI.ActivateReturnButton();
    }

    public void OnItenButton()
    {
        if (PauseController.IsGamePaused) return;
        AudioManager.Instance.PlaySFX(enterMenu, true);
        verificateButtonUI.DisactivateButtons();
        verificateButtonUI.ActivateItensPanel();
        verificateButtonUI.ActivateReturnButton();
    }

    public void OnBackButton()
    {
        if (PauseController.IsGamePaused) return;
        AudioManager.Instance.PlaySFX(backMenu, true);

        if (GameStateController.Instance.GetCurrentState() == "StartGame")
        {
            PauseController.SetPause(true);
            dialogueManager = FindAnyObjectByType<DialogueManager>();
            dialogueManager.StartDialogue(dialogueSequenceStartGame);
            return;
        }

        battleSystem.SavePlayers();
        AudioManager.Instance.StopBGM();
        SceneManager.LoadScene(sceneExplorer);
    }

    public void OnReturnButton()
    {
        AudioManager.Instance.PlaySFX(backMenu, true);
        verificateButtonUI.DisactivateReturnButton();
        verificateButtonUI.ActivateButtons();
    }

    public void OnReturnMenu()
    {
        AudioManager.Instance.PlaySFX(backMenu, true);
        AudioManager.Instance.StopBGM();
        SceneManager.LoadScene(sceneMenu);
    }

    public void OnLoadGame()
    {
        AudioManager.Instance.PlaySFX(LoadGame, true);
        AudioManager.Instance.StopBGM();
        SceneManager.LoadScene(GameManager.Load());
    }

}
