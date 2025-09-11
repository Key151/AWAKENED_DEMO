using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    VerificateButtonUI VerificateButtonUI;
    EnemyButtonController EnemyButtonController;
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
    private Text turnText;
    //private BattleEnemy battleEnemy;

    [Header("ActionCommand")]
    [SerializeField] private BattleManager Maneger;

    [Header("Scene")]
    public string sceneName;

    private BattleState state;
    List<Unit> BattleList;

    [Header("HUD")]
    //HUDController hudController = AddComponent();
    public string namehud;

    [Header("Itens")]
    [SerializeField] private InventoryBattleList inventory;
    private ItensUI itensUI;


    // Start is called before the first frame update
    void Start()
    {
        //Maneger = new BattleManager();
        state = BattleState.START;
        enemyUnit = new List<UnitEnemy>();

        //battleEnemy = new BattleEnemy();
        VerificateButtonUI = GameObject.Find("ButtonsController").GetComponent<VerificateButtonUI>();
        EnemyButtonController = GameObject.Find("EnemyButtonController").GetComponent<EnemyButtonController>();
        itensUI = GameObject.Find("ItensUIController").GetComponent<ItensUI>();

        StartCoroutine(SetupBattle());
    }
    IEnumerator SetupBattle()
    {
        //Cria uma copia do playerPrefab com a posicao do PlayerStation1
        GameObject playerGO = Instantiate(playerPrefab);
        playerUnit = playerGO.GetComponent<UnitPlayerBoy>();

        //Cria uma copia do playerPrefab2 com a posicao do PlayerStation2
        GameObject playerGO_2 = Instantiate(playerPrefab_2);
        playerUnit_2 = playerGO_2.GetComponent<UnitPlayerGirl>();

        for (int i = 0; i <= 2; i++)
        {
            //Cria uma copia do enemyPrefab com a posicao do EnemyStation
            GameObject enemyGO = Instantiate(enemyPrefab[i], enemyBattleStation[i].position, enemyBattleStation[i].rotation);

            //Adiciona na lista (que está vazia) o obj criado pela junção do prefeb e posicao
            enemyUnit.Add(enemyGO.GetComponent<UnitEnemy>());

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
        DisableHudImage();
        VerificateButtonUI.DisactivateDialguePanel();
        UpdateHud(playerHUD, playerUnit);
        UpdateHud(playerHUD_2, playerUnit_2);

        for (int i = BattleList.Count - 1; i >= 0; i--)
        {
            if (BattleList[i].CheckDead())
            {
                BattleList.RemoveAt(i);
            }
        }

        for (int i = enemyUnit.Count - 1; i >= 0; i--) // Desativa o botão do inimgo morto
        {
            if (enemyUnit[i].CheckDead())
            {
                Destroy(enemyUnit[i].gameObject);
                enemyUnit.RemoveAt(i);
                VerificateButtonUI.KillEnemyButton(i);
            }
        }

        if (!BattleList.OfType<UnitEnemy>().Any())
        {
            state = BattleState.WON;
        }

        else if (!BattleList.OfType<UnitPlayer>().Any())
        {
            state = BattleState.LOST;
        }

        else if (BattleList[0] is IVerificateTurnUnit turnUnit)
        {
            state = turnUnit.turnUnit();
        }

        switch (state)
        {
            case BattleState.PLAYERTURN:
                //namehud = BattleList[0].ToString();
                //turnText.text = "Turno: " + namehud;
                //hudController.ChanegenameTurn(turnText);
                Debug.Log("Player:" + BattleList);
                PlayerTurn(BattleList[0]);
                UpdateHudImage(BattleList[0]);
                break;
            case BattleState.ENEMYTURN:
                Debug.Log("Enemy:" + BattleList);
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
        //VerificateButtonUI.MovePanel(BattleList[0] as UnitPlayer);
        player_Unit.HealAP();
        player_Unit.selected = true;
        BattleList[0].selected = true;
    }
    IEnumerator AtackEnemy(Unit player_Unit, int enemyNumber)
    {
        yield return new WaitForSeconds(0.1f);
        UnitPlayer playerAtual = player_Unit as UnitPlayer;

        playerAtual.selected = false;
        Maneger.StartAttackSequence(playerAtual);
        VerificateButtonUI.DisactivateButtons();
        VerificateButtonUI.ActivateDialguePanel();
        dialogueText.text = playerAtual.UnitName + " ataca!";
        playerAtual.Attack(enemyUnit[enemyNumber]);
        enemyHUD[enemyNumber].SetHP(enemyUnit[enemyNumber].CurrentHP);
        //Debug.Log($"{playerAtual} está com {playerAtual.DamageBonus} de dano bonus e atacando {enemyUnit[enemyNumber]}");
        yield return new WaitForSeconds(0.5f);
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
            dialogueText.text = enemy.UnitName + " ataca\n" + player.UnitName + "!";
            enemy.Attack(player);
            //player.takingDamage = true;
            yield return new WaitForSeconds(1f);
            //player.takingDamage = false;
        }

        else
        {
           dialogueText.text = enemy.UnitName + " se cura" + "!";
            yield return new WaitForSeconds(1f);
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
        playerUnit.SaveData();
        playerUnit_2.SaveData();
        SceneManager.LoadScene(sceneName);
    }

    public void OnReturnButton()
    {
        VerificateButtonUI.DisactivateReturnButton();
        VerificateButtonUI.ActivateButtons();
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
    public void OnEnemyButtonAttack(int enemyNumber)
    {
        //VerificateButtonUI.DisactivateButtonsEnemy();
        EnemyButtonController.DisactivateButtonsEnemy();
        VerificateButtonUI.DisactivateReturnButton();
        StartCoroutine(AtackEnemy(BattleList[0], enemyNumber));
    }

    public void OnEnemyButtonIten(int enemyNumber, int itensIndex)
    {
        EnemyButtonController.DisactivateButtonsEnemy();
        VerificateButtonUI.DisactivateReturnButton();
        UseItem(itensIndex, BattleList[0], enemyUnit[enemyNumber], enemyNumber);
    }

    public void UseItem(int index, Unit player, Unit target, int enemyNumber)
    {
        if (index < 0 || index >= inventory.inventoryList.Count) return;

        //inventory.inventoryList[index].ApplyEffect(player, target);
        inventory.inventoryList[index].ApplyEffect(player, enemyUnit[enemyNumber]);
        Debug.Log($"Usou o item {inventory.inventoryList[index].name}");
        itensUI.ReduceQuantityIten(index);
        enemyHUD[enemyNumber].SetHP(enemyUnit[enemyNumber].CurrentHP);

        BattleList.Add(BattleList[0]);
        BattleList.RemoveAt(0);
        VerificateTurn();
    }

    public Unit TurnCheck()
    {
        return BattleList[0];
    }

    public void UpdateHud(BattleHUD hud, Unit unit)
    {
        hud.SetHP(unit.CurrentHP);
        hud.UpdateHPText(unit);
        hud.SetActionPoint(unit);
    }

    public void UpdateHudImage(Unit unit)
    {
        if(unit == playerUnit)
        {
            playerHUD.ActiveHudImage();
        }
        else if (unit == playerUnit_2)
        {
            playerHUD_2.ActiveHudImage();
        }
    }

    public void DisableHudImage()
    {
        playerHUD.DisactiveHudImage();
        playerHUD_2.DisactiveHudImage();
    }

}