/*using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleS : MonoBehaviour
{
    public enum BattleState { START, PLAYERTURN1, PLAYERTURN2, ENEMYTURN, WON, LOST }

    public GameObject playerPrefab;
    public GameObject playerPrefab_2;
    public GameObject[] enemyPrefab;
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
    bool isDead_1;
    bool isDead_2;

    float girlXAttack;
    float girlYAttack;
    float girlXOrigem;
    float girlYOrigem;
    float boyXAttack;
    float boyYAttack;
    float boyXOrigem;
    float boyYOrigem;

    public BattleState state;
    List<int> BattleList;


    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    //private void Update()
    //{
        //Debug.Log(Random.Range(1, 3));
    //}

    IEnumerator SetupBattle()
    {
        //Cria uma copia do playerPrefab com a posi��o do PlayerStation1
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation_2);
        playerUnit = playerGO.GetComponent<Unit>();

        //posição do jogador 1
        playerUnit.xPosition = playerGO.transform.position.x;
        playerUnit.yPosition = playerGO.transform.position.y;
        boyXOrigem = playerUnit.xPosition;
        boyYOrigem = playerUnit.yPosition;

        //Cria uma copia do playerPrefab2 com a posi��o do PlayerStation2
        GameObject playerGO_2 = Instantiate(playerPrefab_2, playerBattleStation);
        playerUnit_2 = playerGO_2.GetComponent<Unit>();

        //posição do jogador 2
        playerUnit_2.xPosition = playerGO_2.transform.position.x;
        playerUnit_2.yPosition = playerGO_2.transform.position.y;
        girlXOrigem = playerUnit_2.xPosition;
        girlYOrigem = playerUnit_2.yPosition;

        //Cria uma copia do enemyPrefab com a posi��o do EnemyStation
        GameObject enemyGO = Instantiate(enemyPrefab[0], enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        //posição do inimigo 1
        enemyUnit.xPosition = enemyGO.transform.position.x;
        enemyUnit.yPosition = enemyGO.transform.position.y;

        BattleList = new List<int>() { playerUnit.Spd, playerUnit_2.Spd, enemyUnit.Spd };
        BattleList.Sort((a, b) => b.CompareTo(a));

        dialogueText.text = " A wild " + enemyUnit.UnitName + " \napproaches...";

        playerHUD.SetHUD(playerUnit);
        playerHUD_2.SetHUD(playerUnit_2);
        enemyHUD.SetHUD(enemyUnit);

        //posição de ataque
        girlXAttack = enemyBattleStation.position.x - 2f;
        girlYAttack = enemyBattleStation.position.y + 1.2f;
        boyXAttack = enemyBattleStation.position.x - 2f;
        boyYAttack = enemyBattleStation.position.y + 1.2f;

        yield return new WaitForSeconds(2f);

        VerificateTurn();
    }
    void VerificateTurn()
    {
        if (enemyUnit.Dead)
        {
            state = BattleState.WON;
            StartCoroutine(EndBattle());
        }

        else if (playerUnit.Dead && playerUnit_2.Dead)
        {
            state = BattleState.LOST;
            StartCoroutine(EndBattle());
        }

        if (BattleList.Count == 0)
        {
        Debug.LogError("BattleList está vazia.");
        return; // Previne erros se a lista estiver vazia
        }

        if (BattleList[0] == playerUnit.Spd)
        {
            state = BattleState.PLAYERTURN1;
            StartCoroutine(PlayerTurn(playerUnit, false));
        }

        else if (BattleList[0] == playerUnit_2.Spd)
        {
            state = BattleState.PLAYERTURN2;
            StartCoroutine(PlayerTurn(playerUnit_2, false));
        }

        else if (BattleList[0] == enemyUnit.Spd)
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn(enemyUnit));
        }
    }

    // TURNO DO PLAYER
    IEnumerator PlayerTurn(Unit playerUnit, bool click)//Criar uma lista de opções com switch case
    {
        //ActivatePanel();
        if (!click)
        {
            ActivateButtons();
            dialogueText.text = "Choose an action,\n" + playerUnit.UnitName;
        }
        else
        {
            DisactivateButtons();
            playerUnit.Attack(enemyUnit);
            enemyHUD.SetHP(enemyUnit.CurrentHP);
            dialogueText.text = playerUnit.UnitName + " attacks!";
            playerUnit.attacking = true;
            //playerUnit_2.transform.position = new Vector3(girlXAttack, girlYAttack);
            yield return new WaitForSeconds(2f);
            //playerUnit_2.transform.position = new Vector3(girlXOrigem, girlYOrigem);
            playerUnit.attacking = false;
            BattleList.Add(BattleList[0]);
            BattleList.RemoveAt(0);
            VerificateTurn();
        }
    }

    // TURNO DO INIMIGO
    IEnumerator EnemyTurn(Unit enemy)
    {
        if ( Random.Range(0,10) >= 3)
        {
            Unit player = choosePlayer(playerUnit, playerUnit_2);
            enemy.Attack(player);
            dialogueText.text = enemy.UnitName + " attacks\n" + player.UnitName;
            playerHUD.SetHP(playerUnit.CurrentHP);
            playerHUD_2.SetHP(playerUnit_2.CurrentHP);
        }

        //Fazer a habilidade de cura
        else
        {
            dialogueText.text = enemy.UnitName + " heals!";
            enemy.Heal(enemy.HealHP);
            enemyHUD.SetHP(enemy.CurrentHP);
        }

        yield return new WaitForSeconds(1f);
        BattleList.Add(BattleList[0]);
        BattleList.RemoveAt(0);
        VerificateTurn();
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

    //Ataque do inimigo
    public Unit choosePlayer(Unit playerturn1, Unit playerturn2)
    {
       //Verificar se está morto
        if (playerturn1.Dead)
        {
            return playerturn2;
        }
        else if (playerturn2.Dead)
        {
            return playerturn1;
        }

        //Qual jogador vai atacar
        if (Random.Range(1, 3) == 1)
        {
            return playerturn1;
        }
        else
        {
            return playerturn2;
        }
    }

    // BOTAO DE ATAQUE


    public void OnAttackButton()
    {
        DisactivateButtons();
        ActivateButtonsEnemy();
    }

    //public void OnAttack()
    //{
        //if (state == BattleState.PLAYERTURN1)
        //{
            //StartCoroutine(PlayerTurn(playerUnit, true));
        //}

        //else if (state == BattleState.PLAYERTURN2)
        //{
            //StartCoroutine(PlayerTurn(playerUnit_2, true));
        //}
    //}


    //BOT�O DE CURA
    public void OnHealButton()
    {
        if (state == BattleState.PLAYERTURN1)
        {
            DisactivateButtons();
            //StartCoroutine(PlayerTurn(playerUnit, true));
        }
        else if (state == BattleState.PLAYERTURN2)
        {
            DisactivateButtons();
            //StartCoroutine(PlayerTurn(playerUnit_2, true));
        }

    }

    //BOT�O DO INIMIGO
    public void OnEnemyButton()
    {
        if (state == BattleState.PLAYERTURN1)
        {
            DisactivateButtonsEnemy();
            StartCoroutine(PlayerTurn(playerUnit, true));

        }
        else if (state == BattleState.PLAYERTURN2)
        {
            DisactivateButtonsEnemy();
            StartCoroutine(PlayerTurn(playerUnit_2, true));

        }
        else
        {
            return;
        }
    }

    // DISATIVAR BOT�ES
    public void DisactivateButtons()
    {
        attackButton.SetActive(false);
        healButton.SetActive(false);
    }

    public void DisactivateButtonsEnemy()
    {
        enemyButton.SetActive(false);
    }

    // ATIVAR BOT�ES

    public void ActivateButtonsEnemy()
    {
        enemyButton.SetActive(true);
        primaryButtonEnemy.Select();
    }
    public void ActivateButtons()
    {
        attackButton.SetActive(true);
        healButton.SetActive(true);
        primaryButtonPlayer.Select();
    }
}
*/