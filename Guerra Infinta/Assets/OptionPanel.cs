using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static BattleSystem;

public class OptionPanel : MonoBehaviour
{
    BattleSystem battleSystem;
    VerificateButtonUI VerificateButtonUI;
    EnemyButtonController EnemyButtonController;

    [Header("Scene")]
    public string sceneName;

    void Start()
    {
        VerificateButtonUI = GameObject.Find("ButtonsController").GetComponent<VerificateButtonUI>();
        EnemyButtonController = GameObject.Find("EnemyButtonController").GetComponent<EnemyButtonController>();
        battleSystem = GameObject.Find("BattleSystem").GetComponent<BattleSystem>();
    }

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
        battleSystem.PLayer(1).SaveData();
        battleSystem.PLayer(2).SaveData();
        SceneManager.LoadScene(sceneName);
    }

    public void OnReturnButton()
    {
        VerificateButtonUI.DisactivateReturnButton();
        VerificateButtonUI.ActivateButtons();
    }


}
