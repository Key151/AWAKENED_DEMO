/*using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum BattleState { START, PLAYERTURN, PLAYERTURN_2, ENEMYTURN, ENEMYTURN_2, ENEMYTURN_3, WON, LOST }

public class BattleSystem : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject playerPrefab_2;
    public GameObject enemyPrefab;
    public Button primaryButtonPlayer;
    public Button primaryButtonEnemy;
    public GameObject attackButton;
    public GameObject healButton;
    public GameObject enemyButton;
    public GameObject dialoguePanel;

    public Transform playerBattleStation;
    public Transform playerBattleStation_2;
    public Transform enemyBattleStation;
    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD playerHUD_2;
    public BattleHUD enemyHUD;

    Unit playerUnit;
    Unit playerUnit_2;
    Unit enemyUnit;

    public string sceneName;
    float girlXAttack;
    float girlYAttack;
    float girlXOrigem;
    float girlYOrigem;
    float boyXAttack;
    float boyYAttack;
    float boyXOrigem;
    float boyYOrigem;

    bool isDead_1;
    bool isDead_2;

    public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation_2);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject playerGO_2 = Instantiate(playerPrefab_2, playerBattleStation);
        playerUnit_2 = playerGO_2.GetComponent<Unit>();

        playerUnit.xPosition = playerGO.transform.position.x;
        playerUnit.yPosition = playerGO.transform.position.y;
        boyXOrigem = playerUnit.xPosition;
        boyYOrigem = playerUnit.yPosition;

        playerUnit_2.xPosition = playerGO_2.transform.position.x;
        playerUnit_2.yPosition = playerGO_2.transform.position.y;
        girlXOrigem = playerUnit_2.xPosition;
        girlYOrigem = playerUnit_2.yPosition;

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        enemyUnit.xPosition = enemyGO.transform.position.x;
        enemyUnit.yPosition = enemyGO.transform.position.y;

        dialogueText.text = " A wild " + enemyUnit.unitName + " \napproaches...";

        playerHUD.SetHUD(playerUnit);
        playerHUD_2.SetHUD(playerUnit_2);
        enemyHUD.SetHUD(enemyUnit);

        girlXAttack = enemyBattleStation.position.x - 2f;
        girlYAttack = enemyBattleStation.position.y + 1.2f;
        boyXAttack = enemyBattleStation.position.x - 2f;
        boyYAttack = enemyBattleStation.position.y + 1.2f;

        playerUnit_2.attacking = false;

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    // TURNO DO PLAYER
    void PlayerTurn()
    {
        //ActivatePanel();
        dialogueText.text = "Choose an action,\n" + playerUnit.unitName;
        ActivateButtons();
    }

    void PlayerTurn_2()

    {
        //ActivatePanel();
        dialogueText.text = "Choose an action,\n" + playerUnit_2.unitName;
        ActivateButtons();
    }

    // PLAYER  1 ATACA
    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);

        dialogueText.text = playerUnit.unitName + " attacks!";

        playerUnit.attacking = true;

        playerUnit.transform.position = new Vector3(boyXAttack ,boyYAttack);

        yield return new WaitForSeconds(2f);

        playerUnit.attacking = false;

        playerUnit.transform.position = new Vector3(boyXOrigem, boyYOrigem);

        if (isDead)
        {
            state = BattleState.WON;
            StartCoroutine(EndBattle());
        }
        else
        {
            if (isDead_2)
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            }
            else
             {
                state = BattleState.PLAYERTURN_2;
                PlayerTurn_2();
            }
        }
    }

    // PLAYER 2 ATACA

    IEnumerator PlayerAttack_2()
    {

        bool isDead = enemyUnit.TakeDamage(playerUnit_2.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);

        dialogueText.text = playerUnit_2.unitName + " attacks!";

        playerUnit_2.attacking = true;

        playerUnit_2.transform.position = new Vector3(girlXAttack, girlYAttack);

        yield return new WaitForSeconds(2f);

        playerUnit_2.attacking = false;

        playerUnit_2.transform.position = new Vector3(girlXOrigem, girlYOrigem);

        if (isDead)
         {
            state = BattleState.WON;
            StartCoroutine(EndBattle());
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

    }

    // PLAYER 1 CURA
    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(playerUnit.healHP);

        playerHUD.SetHP(playerUnit.currentHP);

        playerHUD.UpdateHPText(playerUnit);

        dialogueText.text = playerUnit.unitName + " heals!";

        yield return new WaitForSeconds(2f);

        if (isDead_2)
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        else
        {
            state = BattleState.PLAYERTURN_2;
            PlayerTurn_2();
        }
    }

    // PLAYER 2 CURA

    IEnumerator PlayerHeal_2()
    {
        playerUnit_2.Heal(playerUnit_2.healHP);

        playerHUD_2.SetHP(playerUnit_2.currentHP);

        playerHUD_2.UpdateHPText(playerUnit_2);

        dialogueText.text = playerUnit_2.unitName + " heals!";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerUseMP()
    {

        if (playerUnit.currentMP >= playerUnit.useMP)
        {
            playerUnit.UseMP();
            playerHUD.SetMP(playerUnit);

            state = BattleState.PLAYERTURN_2;
            PlayerTurn_2();

        }
        else
        {
            dialogueText.text = playerUnit.unitName + " não tem MP sulficiente";

            PlayerTurn();

        }


        yield return new WaitForSeconds(2f);
    }

    IEnumerator Player_2UseMP()
    {

        if (playerUnit_2.currentMP >= playerUnit_2.useMP)
        {
            playerUnit_2.UseMP();
            playerHUD_2.SetMP(playerUnit_2);

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

        }
        else
        {
            dialogueText.text = playerUnit_2.unitName + " não tem MP sulficiente";

            PlayerTurn_2();
        }


        yield return new WaitForSeconds(2f);
    }


    // BATALHA ACABA
    IEnumerator EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "You won the battle!";
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(sceneName);
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated.";
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(sceneName);
        }
    }


    // BOTÃO DE ATAQUE
    //public void OnAttackButton()
    //{
        //if (state == BattleState.PLAYERTURN)
        //{
            //DisactivateButtons();
            //StartCoroutine(PlayerAttack());

        //}else if (state == BattleState.PLAYERTURN_2)
        //{
            //DisactivateButtons();
            //StartCoroutine(PlayerAttack_2());

        //}else
        //{
            //return;
        //}

    //}

    public void OnAttackButton()
    {
        DisactivateButtons();
        ActivateButtonsEnemy();
    }

    public void OnEnemyButton()
    {
        if (state == BattleState.PLAYERTURN)
        {
            DisactivateButtonsEnemy();
            StartCoroutine(PlayerAttack());

        }
        else if (state == BattleState.PLAYERTURN_2)
        {
            DisactivateButtonsEnemy();
            StartCoroutine(PlayerAttack_2());

        }
        else
        {
            return;
        }
    }


    //BOTÃO DE CURA
    public void OnHealButton()
    {
        if (state == BattleState.PLAYERTURN)
        {
            DisactivateButtons();
            StartCoroutine(PlayerHeal());
        }
        else if (state == BattleState.PLAYERTURN_2)
        {
            DisactivateButtons();
            StartCoroutine(PlayerHeal_2());
        }else
        {
            return;
        }

    }

    public void OnMPButton()
    {
        if (state == BattleState.PLAYERTURN)
        {
            StartCoroutine(PlayerUseMP());
        }
        else if (state == BattleState.PLAYERTURN_2)
        {
            StartCoroutine(Player_2UseMP());
        }else
        {
            return;
        }
    }



    // DISATIVAR PAINEL
    //public void DisactivatePanel()
    //{
    //    dialoguePanel.SetActive(false);
    //}

    // ATIVAR PAINEL
    //public void ActivatePanel()
    //{
    //    dialoguePanel.SetActive(true);
    //}

    // DISATIVAR BOTÕES
    public void DisactivateButtons()
    {
        attackButton.SetActive(false);
        healButton.SetActive(false);
    }

    // ATIVAR BOTÕES
    public void ActivateButtons()
    {
        attackButton.SetActive(true);
        healButton.SetActive(true);
        primaryButtonPlayer.Select();
    }

    public void ActivateButtonsEnemy()
    {
        enemyButton.SetActive(true);
        primaryButtonEnemy.Select();
    }

    public void DisactivateButtonsEnemy()
    {
        enemyButton.SetActive(false);
    }

}
*/