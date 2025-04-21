using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    VerificateButtonUI VerificateButtonUI;
    public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
    private enum Action { AtkNormal, Item, Def, Move }

    //Game Object
    [Header("Player Settings")]
    public GameObject playerPrefab;
    public GameObject playerPrefab_2;
    public Transform playerBattleStation;
    public Transform playerBattleStation_2;
    UnitPlayerBoy playerUnit;
    UnitPlayerGirl playerUnit_2;
    public BattleHUD playerHUD;
    public BattleHUD playerHUD_2;


    [Header("Enemy Settings")]
    public GameObject[] enemyPrefab;
    private List<UnitEnemy> enemyUnit;
    public List<Transform> enemyBattleStation;
    public List<BattleHUD> enemyHUD;


    [Header("Dialogue Settings")]
    public Text dialogueText;


    public string sceneName;

    private BattleState state;
    List<Unit> BattleList;


    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        enemyUnit = new List<UnitEnemy>();
        VerificateButtonUI = GameObject.Find("Buttons").GetComponent<VerificateButtonUI>();
        StartCoroutine(SetupBattle());
    }
    IEnumerator SetupBattle()
    {
        //Cria uma copia do playerPrefab com a posicao do PlayerStation1
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation_2);
        playerUnit = playerGO.GetComponent<UnitPlayerBoy>();

        //posição do jogador 1
        playerUnit.OrigenX = playerGO.transform.position.x;
        playerUnit.OrigenY = playerGO.transform.position.y;

        //Cria uma copia do playerPrefab2 com a posicao do PlayerStation2
        GameObject playerGO_2 = Instantiate(playerPrefab_2, playerBattleStation);
        playerUnit_2 = playerGO_2.GetComponent<UnitPlayerGirl>();

        //posição do jogador 2
        playerUnit_2.OrigenX = playerGO_2.transform.position.x;
        playerUnit_2.OrigenY = playerGO_2.transform.position.y;

        for (int i = 0; i <= 2; i++)
        {
            //Cria uma copia do enemyPrefab com a posicao do EnemyStation
            GameObject enemyGO = Instantiate(enemyPrefab[i], enemyBattleStation[i]);

            //Adiciona na lista (que está vazia) o obj criado pela junção do prefeb e posicao
            enemyUnit.Add(enemyGO.GetComponent<UnitEnemy>());

            //posição do inimigo
            enemyUnit[i].SetPosition(enemyGO.transform.position.x, enemyGO.transform.position.y);

            enemyHUD[i].SetHUD(enemyUnit[i]);
        }

        BattleList = new List<Unit>() { playerUnit, playerUnit_2 };

        foreach (var enemy in enemyUnit)
        {
            BattleList.Add(enemy);
        }

        BattleList.Sort((a, b) => b.Spd.CompareTo(a.Spd));

        VerificateButtonUI.ActivateDialguePanel();

        dialogueText.text = "Um " + enemyUnit[0].UnitName + " Apareceu...\n";

        playerHUD.SetHUD(playerUnit);
        playerHUD_2.SetHUD(playerUnit_2);
        enemyHUD[0].SetHUD(enemyUnit[0]);



        yield return new WaitForSeconds(3f);

        VerificateTurn();
    }
    void VerificateTurn()
    {
        VerificateButtonUI.DisactivateDialguePanel();

        for (int i = 0; i > BattleList.Count; i++)
        {
            if (BattleList[i].CheckDead())
            {
                BattleList.RemoveAt(i);
            }
        }

        if (!BattleList.OfType<UnitPlayer>().Any())
        {
            state = BattleState.WON;
        }

        else if (!BattleList.OfType<UnitEnemy>().Any())
        {
            state = BattleState.LOST;
        }

        if (BattleList[0] is IVerificateTurnUnit turnUnit)
        {
            state = turnUnit.turnUnit();
        }

        switch (state)
        {
            case BattleState.PLAYERTURN:
                StartCoroutine(PlayerTurn(BattleList[0], false, 0));
                break;
            case BattleState.ENEMYTURN:
                StartCoroutine(EnemyTurn(BattleList[0]));
                break;
        }

    }

    // TURNO DO PLAYER
    IEnumerator PlayerTurn(Unit player_Unit, bool click, Action action)//Criar uma lista de opções com switch case
    {
        //ActivatePanel();
        if (!click)
        {
            VerificateButtonUI.ActivateButtons();
            player_Unit.selected = true;
        }
        else
        {
            switch (action)
            {
                case Action.AtkNormal://Ataque
                    {
                        BattleList[0].selected = false;
                        VerificateButtonUI.DisactivateButtons();
                        VerificateButtonUI.ActivateDialguePanel();
                        BattleList[0].Attack(enemyUnit[0]);
                        enemyHUD[0].SetHP(enemyUnit[0].CurrentHP);
                        dialogueText.text = BattleList[0].UnitName + " ataca!";
                        playerUnit.MoveAtk(enemyUnit[0].transform);
                        yield return new WaitForSeconds(2f);
                        //DisactivateDialguePanel();
                        BattleList[0].transform.position = new Vector2(player_Unit.OrigenX, player_Unit.OrigenY);
                        BattleList[0].attacking = false;
                        BattleList.Add(BattleList[0]);
                        BattleList.RemoveAt(0);
                        VerificateTurn();
                        break;
                    }
                //case Action.AtkSP://Cura
                //    {
                //        VerificateButtonUI.DisactivateButtons();
                //        if (player_Unit.CurrentActionPoint < player_Unit.UseActionPoint)
                //        {
                //            player_Unit.selected = false;
                //            VerificateButtonUI.ActivateDialguePanel();
                //            dialogueText.text = player_Unit.UnitName + " não tem ActionPoint sulficiente!";
                //            yield return new WaitForSeconds(2f);
                //            //DisactivateDialguePanel();
                //            VerificateTurn();
                //        }
                //        else
                //        {
                //            player_Unit.selected = false;
                //            VerificateButtonUI.ActivateDialguePanel();
                //            player_Unit.ActionPoint();
                //            player_Unit.Heal(player_Unit.HealHP);
                //            UpdateHud(playerHUD, playerUnit);
                //            UpdateHud(playerHUD_2, playerUnit_2);
                //            dialogueText.text = player_Unit.UnitName + " se curou!";
                //            yield return new WaitForSeconds(2f);
                //            //DisactivateDialguePanel();
                //            BattleList.Add(BattleList[0]);
                //            BattleList.RemoveAt(0);
                //            VerificateTurn();
                //        }
                //        break;
                //    }
            }
        }
    }

    // TURNO DO INIMIGO
    IEnumerator EnemyTurn(Unit enemy)
    {
        if (Random.Range(0, 10) >= 3)
        {
            Unit player = ChoosePlayer(playerUnit, playerUnit_2);

            VerificateButtonUI.ActivateDialguePanel();
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
        //else
        //{
        //    VerificateButtonUI.ActivateDialguePanel();
        //    dialogueText.text = enemy.UnitName + " se cura!";
        //    enemy.Heal(enemy.HealHP);
        //    enemyHUD[0].SetHP(enemy.CurrentHP);
        //    yield return new WaitForSeconds(2f);
        //    //DisactivateDialguePanel();
        //}
        BattleList.Add(BattleList[0]);
        BattleList.RemoveAt(0);
        VerificateTurn();
    }

    // BATALHA ACABA
    IEnumerator EndBattle()
    {
        if (state == BattleState.WON)
        {
            VerificateButtonUI.ActivateDialguePanel();
            dialogueText.text = "Você venceu a batalha!";
            yield return new WaitForSeconds(2f);
            VerificateButtonUI.DisactivateDialguePanel();
            SceneManager.LoadScene(sceneName);
        }
        else if (state == BattleState.LOST)
        {
            VerificateButtonUI.ActivateDialguePanel();
            dialogueText.text = "Você foi derrotado.";
            yield return new WaitForSeconds(2f);
            VerificateButtonUI.DisactivateDialguePanel();
            SceneManager.LoadScene(sceneName);
        }
    }

    //Ataque do inimigo
    public Unit ChoosePlayer(Unit playerturn1, Unit playerturn2)
    {
        ////Verificar se está morto
        //if (playerturn1.Dead)
        //{
        //    return playerturn2;
        //}
        //else if (playerturn2.Dead)
        //{
        //    return playerturn1;
        //}

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
        VerificateButtonUI.DisactivateButtons();
        VerificateButtonUI.SelectEnemy();
    }

    public void OnMPButton()
    {
        VerificateButtonUI.DisactivateButtons();
        VerificateButtonUI.ActivateButtonsMP();
    }

    public void OnToMovementButton()
    {
        VerificateButtonUI.DisactivateButtonsMP();
        VerificateButtonUI.ActivateButtonsMovement();
    }
    public void OnReturnButton()
    {
        VerificateButtonUI.DisactivateButtonsMovement();
        VerificateButtonUI.ActivateButtons();
    }

    public void OnMoveButton()
    {
        VerificateButtonUI.DisactivateButtonsMovement();
    }

    //BOTAO DE CURA
    //public void OnHealButton()
    //{
    //    if (state == BattleState.PLAYERTURN1)
    //    {
    //        VerificateButtonUI.DisactivateButtonsMP();
    //        StartCoroutine(PlayerTurn(playerUnit, true, Action.AtkSP));
    //    }
    //    else if (state == BattleState.PLAYERTURN2)
    //    {
    //        VerificateButtonUI.DisactivateButtonsMP();
    //        StartCoroutine(PlayerTurn(playerUnit_2, true, Action.AtkSP));
    //    }

    //}

    //BOTAO DO INIMIGO
    public void OnEnemyButton()
    {
        VerificateButtonUI.DisactivateButtonsEnemy();
        StartCoroutine(PlayerTurn(BattleList[0], true, Action.AtkNormal));
    }

    public void UpdateHud(BattleHUD hud, Unit unit)
    {
        hud.SetHP(unit.CurrentHP);
        hud.UpdateHPText(unit);
        hud.SetActionPoint(unit);
    }
}