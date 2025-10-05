using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionPanel : MonoBehaviour
{
    [Header("Scene")]
    public string sceneName;

    [Header("Classes")]
    [SerializeField] private BattleSystem battleSystem;
    [SerializeField] private VerificateButtonUI verificateButtonUI;
    [SerializeField] private EnemyButtonController enemyButtonController;

    public void OnAttackButton()
    {
        verificateButtonUI.DisactivateButtons();
        enemyButtonController.SelectEnemyButtonAtack();
        verificateButtonUI.ActivateReturnButton();
    }

    public void OnItenButton()
    {
        verificateButtonUI.DisactivateButtons();
        verificateButtonUI.ActivateItensPanel();
        verificateButtonUI.ActivateReturnButton();
    }

    public void OnBackButton()
    {
        battleSystem.SavePlayers();
        AudioManager.Instance.StopBGM();
        SceneManager.LoadScene(sceneName);
    }

    public void OnReturnButton()
    {
        verificateButtonUI.DisactivateReturnButton();
        verificateButtonUI.ActivateButtons();
    }


}
