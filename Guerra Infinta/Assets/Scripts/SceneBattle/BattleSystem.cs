using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private UnitPlayerBoy playerUnit;
    private UnitPlayerGirl playerUnit_2;
    public BattleHUD playerHUD;
    public BattleHUD playerHUD_2;


    [Header("Enemy Settings")]
    public GameObject[] enemyPrefab;
    private List<UnitEnemy> enemyUnit;
    public List<Transform> enemyBattleStation;
    public List<BattleHUD> enemyHUD;


    [Header("Dialogue Settings")]
    public Text dialogueText;
    //private BattleEnemy battleEnemy;

    [Header("ActionCommand")]
    [SerializeField] private BattleManager Maneger;

    [Header("Scene")]
    public string sceneName;

    private BattleState state;
    List<Unit> BattleList;


    // Start is called before the first frame update
    void Start()
    {
        //Maneger = new BattleManager();
        state = BattleState.START;
        enemyUnit = new List<UnitEnemy>();

        //battleEnemy = new BattleEnemy();
        VerificateButtonUI = GameObject.Find("ButtonsController").GetComponent<VerificateButtonUI>();

        //battleEnemy = new BattleEnemy();
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

        yield return new WaitForSeconds(3f);

        VerificateTurn();
    }
    void VerificateTurn()
    {
        VerificateButtonUI.DisactivateDialguePanel();
        UpdateHud(playerHUD, playerUnit);
        UpdateHud(playerHUD_2, playerUnit_2);

        Debug.Log(BattleList.Count);

        for (int i = 0; i < BattleList.Count; i++)
        {
            if (BattleList[i].CheckDead())
            {
                BattleList.RemoveAt(i);
                //BattleList.Remove(BattleList[i]);
            }
        }

        for (int i = 0; i < enemyUnit.Count; i++) // Desativa o botão do inimgo morto
        {
            if (enemyUnit[i].CheckDead())
            {
                VerificateButtonUI.KillEnemyButton(i);
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
                PlayerTurn(BattleList[0]);
                break;
            case BattleState.ENEMYTURN:
                StartCoroutine(EnemyTurn(BattleList[0]));
                break;
            default:
                StartCoroutine(EndBattle());
                break;
        }

    }

    // TURNO DO PLAYER
    void PlayerTurn(Unit player_Unit)
    {
        VerificateButtonUI.ActivateButtons();
        VerificateButtonUI.MovePanel(BattleList[0] as UnitPlayer);
        player_Unit.HealAP();
        player_Unit.selected = true;
        BattleList[0].selected = true;
    }
    IEnumerator AtackEnemy(Unit player_Unit, int enemyNumber)
    {
        yield return new WaitForSeconds(0.25f);
        UnitPlayer playerAtual = player_Unit as UnitPlayer;

        playerAtual.selected = false;
        Maneger.StartAttackSequence(playerAtual);
        playerAtual.MoveAtk(enemyUnit[enemyNumber].transform);
        playerAtual.attacking = true;
        yield return new WaitForSeconds(1.5f);
        VerificateButtonUI.DisactivateButtons();
        VerificateButtonUI.ActivateDialguePanel();
        playerAtual.Attack(enemyUnit[enemyNumber]);
        enemyHUD[enemyNumber].SetHP(enemyUnit[enemyNumber].CurrentHP);
        dialogueText.text = playerAtual.UnitName + " ataca!";
        Debug.Log($"{playerAtual} está com {playerAtual.DamageBonus} de dano bonus e atacando {enemyUnit[enemyNumber]}");
        yield return new WaitForSeconds(0.5f);
        playerAtual.transform.position = new Vector2(playerAtual.OrigenX, playerAtual.OrigenY);
        playerAtual.attacking = false;
        BattleList.Add(BattleList[0]);
        BattleList.RemoveAt(0);
        VerificateTurn();
    }

    // TURNO DO INIMIGO
    IEnumerator EnemyTurn(Unit enemy)
    {
        UnitPlayer player = ChoosePlayer(playerUnit, playerUnit_2);

        VerificateButtonUI.ActivateDialguePanel();
        //battleEnemy.SystemEnemyBattle(enemy as UnitEnemy, player);

        if (Random.Range(0, 10) >= 3)
        {
            enemy.Attack(player);
            player.takingDamage = true;
            dialogueText.text = enemy.UnitName + " ataca\n" + player.UnitName + "!";
            yield return new WaitForSeconds(2f);
            player.takingDamage = false;
        }

        else
        {
           dialogueText.text = enemy.UnitName + " se cura" + "!";
            yield return new WaitForSeconds(2f);
        }

        VerificateButtonUI.DisactivateDialguePanel();
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

    // BOTAO DE ATAQUE

    public void OnAttackButton()
    {
        VerificateButtonUI.DisactivateButtons();
        VerificateButtonUI.SelectEnemy();
    }

    public void OnReturnButton()
    {
        SceneManager.LoadScene("Scene1 1");
        //VerificateButtonUI.DisactivateButtonsMovement();
        //VerificateButtonUI.ActivateButtons();
    }


    // Escolhe o jogador que vai atacar
    private UnitPlayer ChoosePlayer(UnitPlayer playerturn1, UnitPlayer playerturn2)
    {
        if (Random.Range(1, 3) == 1)
        {
            return playerturn1;
        }
        else
        {
            return playerturn2;
        }
    }

    //BOTAO DO INIMIGO
    public void OnEnemyButton(int enemyNumber)
    {
        VerificateButtonUI.DisactivateButtonsEnemy();
        StartCoroutine(AtackEnemy(BattleList[0], enemyNumber));
    }

    public void UpdateHud(BattleHUD hud, Unit unit)
    {
        hud.SetHP(unit.CurrentHP);
        hud.UpdateHPText(unit);
        hud.SetActionPoint(unit);
    }
}