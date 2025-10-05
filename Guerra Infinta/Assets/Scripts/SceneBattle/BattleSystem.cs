using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
    private enum Action { AtkNormal, Item, Def, Move }
    private BattleState state;
    private List<Unit> BattleList;

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
    [SerializeField] private float timer;
    [SerializeField] private List<GameObject> enemyPrefab;
    private List<UnitEnemy> enemyUnit;
    public List<Transform> enemyBattleStation;
    public List<BattleHUD> enemyHUD;
    [SerializeField] EnemyButtonController enemyButtonController;



    [Header("Dialogue Settings")]
    public Text dialogueText;
    //private BattleEnemy battleEnemy;

    [Header("ActionCommand")]
    [SerializeField] private BattleManager Maneger;

    [Header("Scene")]
    public string sceneName;

    [Header("Itens")]
    [SerializeField] private InventoryBattleList inventory;

    [Header("Audio")]
    [SerializeField] private string BattleSong = "Battle01";

    [Header("UI")]
    [SerializeField] private ItensUI itensUI;
    [SerializeField] private VerificateButtonUI VerificateButtonUI;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayBGM(BattleSong);
        state = BattleState.START;
        enemyUnit = new List<UnitEnemy>();
        if (enemyPrefab.Count == 0) { enemyPrefab = new List<GameObject>(EnemysList.enemyPrefab); }

        StartCoroutine(SetupBattle());
    }
    IEnumerator SetupBattle()
    {
        //Cria uma playerPrefab no cenario
        GameObject playerGO = Instantiate(playerPrefab);
        playerUnit = playerGO.GetComponent<UnitPlayerBoy>();

        //Cria uma playerPrefab2 no cenario
        GameObject playerGO_2 = Instantiate(playerPrefab_2);
        playerUnit_2 = playerGO_2.GetComponent<UnitPlayerGirl>();

        for (int i = 0; i < enemyPrefab.Count; i++)
        {
            //Cria uma copia do enemyPrefab com a posicao do EnemyStation
            GameObject enemyGO = Instantiate(enemyPrefab[i], enemyBattleStation[i].position, enemyBattleStation[i].rotation);

            //Adiciona na lista (que está vazia) o obj criado pela junção do prefeb e posicao
            enemyUnit.Add(enemyGO.GetComponent<UnitEnemy>());

            enemyHUD[i].SetHUD(enemyUnit[i]);

            enemyButtonController.ActivateEnemyButton(i);
        }

        BattleList = new List<Unit>() { playerUnit, playerUnit_2 };

        foreach (var enemy in enemyUnit)
        {
            BattleList.Add(enemy);
        }

        BattleList.Sort((a, b) => b.Spd.CompareTo(a.Spd));

        VerificateButtonUI.ActivateDialguePanel();

        //dialogueText.text = "Um " + enemyUnit[0].UnitName + " Apareceu...\n";

        playerHUD.SetHUD(playerUnit);
        playerHUD_2.SetHUD(playerUnit_2);

        yield return new WaitForSeconds(timer);

        VerificateTurn();
    }
    void VerificateTurn()
    {
        DisableHudImage();
        VerificateButtonUI.DisactivateDialguePanel();
        playerHUD.UpdateHUD(playerUnit);
        playerHUD_2.UpdateHUD(playerUnit_2);

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
                enemyUnit[i].gameObject.SetActive(false);
                enemyButtonController.KillEnemyButton(i);
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
                PlayerTurn(BattleList[0]);
                UpdateHudImage(BattleList[0]);
                break;
            case BattleState.ENEMYTURN:
                //Debug.Log("Enemy:" + BattleList);
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
        player_Unit.HealAP();
        player_Unit.selected = true;
        BattleList[0].selected = true;
    }
    private IEnumerator AtackEnemy(Unit player_Unit, int enemyNumber)
    {
        UnitPlayer playerAtual = player_Unit as UnitPlayer;

        playerAtual.selected = false;
        Maneger.StartAttackSequence(playerAtual);
        VerificateButtonUI.DisactivateButtons();
        VerificateButtonUI.ActivateDialguePanel();
        dialogueText.text = playerAtual.UnitName + " ataca!";
        playerAtual.Attack(enemyUnit[enemyNumber]);

        yield return new WaitForSeconds(timer);
        //enemyHUD[enemyNumber].UpdateHUD(enemyUnit[enemyNumber]);
        enemyHUD[enemyNumber].EnemySetHP(enemyUnit[enemyNumber].CurrentHP);
        BattleList.Add(BattleList[0]);
        BattleList.RemoveAt(0);
        VerificateTurn();
    }

    // TURNO DO INIMIGO
    private IEnumerator EnemyTurn(Unit enemy)
    {
        UnitPlayer player = ChoosePlayer(playerUnit, playerUnit_2);

        VerificateButtonUI.ActivateDialguePanel();

        dialogueText.text = enemy.UnitName + " ataca\n" + player.UnitName + "!";
        enemy.Attack(player);
        yield return new WaitForSeconds(timer);

        //battleEnemy.SystemEnemyBattle(enemy as UnitEnemy, player);
        /*if (Random.Range(0, 10) >= 3)
        {
            dialogueText.text = enemy.UnitName + " ataca\n" + player.UnitName + "!";
            enemy.Attack(player);
            yield return new WaitForSeconds(timer);
        }
        else
        {
            int heal = Random.Range(5, 15);
            dialogueText.text = enemy.UnitName + " cura " + heal + " de vida!";
            enemy.Heal(heal);
            yield return new WaitForSeconds(timer);
        }*/

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
            yield return new WaitForSeconds(timer * 2);
            VerificateButtonUI.DisactivateDialguePanel();
            SavePlayers();
            SceneManager.LoadScene(sceneName);
        }
        else if (state == BattleState.LOST)
        {
            VerificateButtonUI.ActivateDialguePanel();
            dialogueText.text = "Você foi derrotado.";
            yield return new WaitForSeconds(timer * 2);
            VerificateButtonUI.DisactivateDialguePanel();
            SavePlayers();
            SceneManager.LoadScene(sceneName);
        }

        AudioManager.Instance.StopBGM();
    }

    // Escolhe o jogador que vai atacar
    private UnitPlayer ChoosePlayer(UnitPlayer playerturn1, UnitPlayer playerturn2)
    {
        if (Random.Range(1, 3) == 1)
        {
            if (!playerturn1.CheckDead())
            {
                return playerturn1;
            }
            else
            {
                return playerturn2;
            }
            
        }
        else
        {
            if(!playerturn2.CheckDead())
            {
                return playerturn2;
            }
            else
            {
                return playerturn1;
            }
        }
    }

    public IEnumerator UseItem(int index, int enemyNumber)
    {
        if (index < 0 || index >= inventory.inventoryList.Count) yield return null;

        inventory.inventoryList[index].ApplyEffect(BattleList[0], enemyUnit[enemyNumber]);
        itensUI.ReduceQuantityIten(index);
        enemyHUD[enemyNumber].EnemySetHP(enemyUnit[enemyNumber].CurrentHP);
        //enemyHUD[enemyNumber].UpdateHUD(enemyUnit[enemyNumber]);

        yield return new WaitForSeconds(timer);

        BattleList.Add(BattleList[0]);
        BattleList.RemoveAt(0);
        VerificateTurn();
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


    //Para usar em outros Scripts
    public void GetToAttackEnemy(int enemyNumber)
    {
        StartCoroutine(AtackEnemy(BattleList[0], enemyNumber));
    }

    public void SavePlayers()
    {
        playerUnit.SaveData();
        playerUnit_2.SaveData();
    }

}