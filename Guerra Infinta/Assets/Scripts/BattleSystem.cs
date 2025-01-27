using System.Collections;
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
    public Button primaryButtonPlayer_2;
    public Button primaryButtonEnemy;

    public GameObject attackButton;
    public GameObject mpButton;
    public GameObject healButton;
    public GameObject returnButton;
    public GameObject enemyButton;
    public GameObject optionPanel;
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

    public BattleState state;
    List<int> BattleList;


    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    /*private void Update()
    {
        Debug.Log(Random.Range(1, 3));
    }*/

    IEnumerator SetupBattle()
    {
        //Cria uma copia do playerPrefab com a posi��o do PlayerStation1
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation_2);
        playerUnit = playerGO.GetComponent<Unit>();

        //posição do jogador 1
        playerUnit.OrigenX = playerGO.transform.position.x;
        playerUnit.OrigenY = playerGO.transform.position.y;

        //Cria uma copia do playerPrefab2 com a posi��o do PlayerStation2
        GameObject playerGO_2 = Instantiate(playerPrefab_2, playerBattleStation);
        playerUnit_2 = playerGO_2.GetComponent<Unit>();

        //posição do jogador 2
        playerUnit_2.OrigenX = playerGO_2.transform.position.x;
        playerUnit_2.OrigenY = playerGO_2.transform.position.y;

        //Cria uma copia do enemyPrefab com a posi��o do EnemyStation
        GameObject enemyGO = Instantiate(enemyPrefab[0], enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        //posição do inimigo 1
        enemyUnit.xPosition = enemyGO.transform.position.x;
        enemyUnit.yPosition = enemyGO.transform.position.y;

        BattleList = new List<int>() { playerUnit.Spd, playerUnit_2.Spd, enemyUnit.Spd };
        BattleList.Sort((a, b) => b.CompareTo(a));

        ActivateDialguePanel();
        dialogueText.text = "Um " + enemyUnit.UnitName + " Apareceu...\n";

        playerHUD.SetHUD(playerUnit);
        playerHUD_2.SetHUD(playerUnit_2);
        enemyHUD.SetHUD(enemyUnit);

        //posição de ataque
        playerUnit.AttackX = enemyBattleStation.position.x - 2f;
        playerUnit.AttackY = enemyBattleStation.position.y + 1.2f;
        playerUnit_2.AttackX = enemyBattleStation.position.x - 2f;
        playerUnit_2.AttackY = enemyBattleStation.position.y + 1.2f;

        yield return new WaitForSeconds(3f);

        VerificateTurn();
    }
    void VerificateTurn()
    {
        DisactivateDialguePanel();
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

        /*else if (BattleList.Count == 0)
        {
            Debug.LogError("BattleList está vazia.");
            return; // Previne erros se a lista estiver vazia
        }*/

        else if (BattleList[0] == playerUnit.Spd)
        {
            if(playerUnit.Dead)
            {
                BattleList.Add(BattleList[0]);
                BattleList.RemoveAt(0);
                VerificateTurn();
            }
            else
            {
                state = BattleState.PLAYERTURN1;
                StartCoroutine(PlayerTurn(playerUnit, false, 0));
            }
        }

        else if (BattleList[0] == playerUnit_2.Spd)
        {
            if(playerUnit_2.Dead)
            {
                BattleList.Add(BattleList[0]);
                BattleList.RemoveAt(0);
                VerificateTurn();
            }
            else
            {
                state = BattleState.PLAYERTURN2;
                StartCoroutine(PlayerTurn(playerUnit_2, false, 0));
            }
        }
        else if (BattleList[0] == enemyUnit.Spd)
        {
            if(enemyUnit.Dead)
            {
                BattleList.Add(BattleList[0]);
                BattleList.RemoveAt(0);
                VerificateTurn();
            }
            else
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn(enemyUnit));
            }
        }
    }

    // TURNO DO PLAYER
    IEnumerator PlayerTurn(Unit player_Unit, bool click, int action)//Criar uma lista de opções com switch case
    {
        //ActivatePanel();
        if (!click)
        {
            ActivateButtons();
            player_Unit.selected = true;
        }
        else
        {
            switch(action)
            {
                case 1://Ataque
                    {
                        player_Unit.selected = false;
                        DisactivateButtons();
                        ActivateDialguePanel();
                        player_Unit.Attack(enemyUnit);
                        enemyHUD.SetHP(enemyUnit.CurrentHP);
                        dialogueText.text = player_Unit.UnitName + " ataca!";
                        player_Unit.attacking = true;
                        player_Unit.transform.position = new Vector3(player_Unit.AttackX, player_Unit.AttackY);
                        yield return new WaitForSeconds(2f);
                        //DisactivateDialguePanel();
                        player_Unit.transform.position = new Vector3(player_Unit.OrigenX, player_Unit.OrigenY);
                        player_Unit.attacking = false;
                        BattleList.Add(BattleList[0]);
                        BattleList.RemoveAt(0);
                        VerificateTurn();
                        break;
                    }
                case 2://Cura
                    {
                        DisactivateButtons();
                        if(player_Unit.CurrentMP < player_Unit.UseMP)
                        {
                            player_Unit.selected = false;
                            ActivateDialguePanel();
                            dialogueText.text = player_Unit.UnitName + " não tem MP sulficiente!";
                            yield return new WaitForSeconds(2f);
                            //DisactivateDialguePanel();
                            VerificateTurn();
                        }
                        else
                        {
                            player_Unit.selected = false;
                            ActivateDialguePanel();
                            player_Unit.MP();
                            player_Unit.Heal(player_Unit.HealHP);
                            UpdateHud(playerHUD, playerUnit);
                            UpdateHud(playerHUD_2, playerUnit_2);
                            dialogueText.text = player_Unit.UnitName + " se curou!";
                            yield return new WaitForSeconds(2f);
                            //DisactivateDialguePanel();
                            BattleList.Add(BattleList[0]);
                            BattleList.RemoveAt(0);
                            VerificateTurn();
                        }
                        break;
                    }
            }
        }
    }

    // TURNO DO INIMIGO
    IEnumerator EnemyTurn(Unit enemy)
    {
        if (Random.Range(0, 10) >= 3)
        {Unit player = choosePlayer(playerUnit, playerUnit_2);

            ActivateDialguePanel();
            enemy.Attack(player);
            player.takingDamage = true;
            dialogueText.text = enemy.UnitName + " ataca\n" + player.UnitName + "!";
            UpdateHud(playerHUD, playerUnit);
            UpdateHud(playerHUD_2, playerUnit_2);
            yield return new WaitForSeconds(2f);
            //DisactivateDialguePanel();
            player.takingDamage = false;

        }
        //Fazer a habilidade de cura
        else
        {
            ActivateDialguePanel();
            dialogueText.text = enemy.UnitName + " se cura!";
            enemy.Heal(enemy.HealHP);
            enemyHUD.SetHP(enemy.CurrentHP);
            yield return new WaitForSeconds(2f);
            //DisactivateDialguePanel();
        }
        BattleList.Add(BattleList[0]);
        BattleList.RemoveAt(0);
        VerificateTurn();
    }

    // BATALHA ACABA
    IEnumerator EndBattle()
    {
        if (state == BattleState.WON)
        {
            ActivateDialguePanel();
            dialogueText.text = "Você venceu a batalha!";
            yield return new WaitForSeconds(2f);
            DisactivateDialguePanel();
            SceneManager.LoadScene(sceneName);
        }
        else if (state == BattleState.LOST)
        {
            ActivateDialguePanel();
            dialogueText.text = "Você foi derrotado.";
            yield return new WaitForSeconds(2f);
            DisactivateDialguePanel();
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

    public void OnMPButton()
    {
        DisactivateButtons();
        ActivateButtonsMP();
    }

    public void OnReturnButton()
    {
        DisactivateButtonsMP();
        ActivateButtons();
    }

    /*public void OnAttack()
    {
        if (state == BattleState.PLAYERTURN1)
        {
            StartCoroutine(PlayerTurn(playerUnit, true));
        }

        else if (state == BattleState.PLAYERTURN2)
        {
            StartCoroutine(PlayerTurn(playerUnit_2, true));
        }
    }*/


    //BOT�O DE CURA
    public void OnHealButton()
    {
        if (state == BattleState.PLAYERTURN1)
        {
            DisactivateButtonsMP();
            StartCoroutine(PlayerTurn(playerUnit, true, 2));
        }
        else if (state == BattleState.PLAYERTURN2)
        {
            DisactivateButtonsMP();
            StartCoroutine(PlayerTurn(playerUnit_2, true, 2));
        }

    }

    //BOT�O DO INIMIGO
    public void OnEnemyButton()
    {
        if (state == BattleState.PLAYERTURN1)
        {
            DisactivateButtonsEnemy();
            StartCoroutine(PlayerTurn(playerUnit, true, 1));

        }
        else if (state == BattleState.PLAYERTURN2)
        {
            DisactivateButtonsEnemy();
            StartCoroutine(PlayerTurn(playerUnit_2, true, 1));

        }
        else
        {
            return;
        }
    }

    public void UpdateHud(BattleHUD hud, Unit unit)
    {
        hud.SetHP(unit.CurrentHP);
        hud.UpdateHPText(unit);
        hud.SetMP(unit);
    }

    // DISATIVAR BOT�ES
    public void DisactivateButtons()
    {
        attackButton.SetActive(false);
        mpButton.SetActive(false);
        optionPanel.SetActive(false);
    }

    public void DisactivateButtonsEnemy()
    {
        enemyButton.SetActive(false);
    }

    public void DisactivateDialguePanel()
    {
        dialoguePanel.SetActive(false);
    }

    public void DisactivateButtonsMP()
    {
        healButton.SetActive(false);
        returnButton.SetActive(false);
        optionPanel.SetActive(false);
    }

    // ATIVAR BOT�ES
    public void ActivateButtonsMP()
    {
        optionPanel.SetActive(true);
        healButton.SetActive(true);
        returnButton.SetActive(true);
        primaryButtonPlayer_2.Select();
    }

    public void ActivateButtonsEnemy()
    {
        enemyButton.SetActive(true);
        primaryButtonEnemy.Select();
    }
    public void ActivateButtons()
    {
        optionPanel.SetActive(true);
        attackButton.SetActive(true);
        mpButton.SetActive(true);
        primaryButtonPlayer.Select();
    }
    public void ActivateDialguePanel()
    {
        dialoguePanel.SetActive(true);
    }
}
