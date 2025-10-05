using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionPanel : MonoBehaviour
{
    [Header("Scene")]
    public string sceneName;

    [Header("Classes")]
    [SerializeField] private BattleSystem battleSystem;
    [SerializeField] private VerificateButtonUI VerificateButtonUI;
    [SerializeField] private EnemyButtonController EnemyButtonController;

    public void OnAttackButton()
    {
        VerificateButtonUI.DisactivateButtons();
        EnemyButtonController.SelectEnemyButtonAtack();
        VerificateButtonUI.ActivateReturnButton();
    }

    public void OnItenButton()
    {
        VerificateButtonUI.DisactivateButtons();
        VerificateButtonUI.ActivateItensPanel();
        VerificateButtonUI.ActivateReturnButton();
    }

    public void OnBackButton()
    {
        battleSystem.SavePlayers();
        AudioManager.Instance.StopBGM();
        SceneManager.LoadScene(sceneName);
    }

    public void OnReturnButton()
    {
        VerificateButtonUI.DisactivateReturnButton();
        VerificateButtonUI.ActivateButtons();
    }


}
