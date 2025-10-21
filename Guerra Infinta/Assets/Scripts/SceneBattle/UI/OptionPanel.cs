using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionPanel : MonoBehaviour
{
    [Header("Scene")]
    public string sceneName;

    [Header("Music")]
    private string enterMenu = "Enter";
    private string backMenu = "Back";

    [Header("Classes")]
    [SerializeField] private BattleSystem battleSystem;
    [SerializeField] private VerificateButtonUI verificateButtonUI;
    [SerializeField] private EnemyButtonController enemyButtonController;

    public void OnAttackButton()
    {
        AudioManager.Instance.PlaySFX(enterMenu, true);
        verificateButtonUI.DisactivateButtons();
        enemyButtonController.SelectEnemyButtonAtack();
        verificateButtonUI.ActivateReturnButton();
    }

    public void OnItenButton()
    {
        AudioManager.Instance.PlaySFX(enterMenu, true);
        verificateButtonUI.DisactivateButtons();
        verificateButtonUI.ActivateItensPanel();
        verificateButtonUI.ActivateReturnButton();
    }

    public void OnBackButton()
    {
        AudioManager.Instance.PlaySFX(backMenu, true);
        battleSystem.SavePlayers();
        AudioManager.Instance.StopBGM();
        SceneManager.LoadScene(sceneName);
    }

    public void OnReturnButton()
    {
        AudioManager.Instance.PlaySFX(backMenu, true);
        verificateButtonUI.DisactivateReturnButton();
        verificateButtonUI.ActivateButtons();
    }


}
