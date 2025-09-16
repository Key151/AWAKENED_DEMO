using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItensUI : MonoBehaviour
{
    VerificateButtonUI verificateButtonUI;
    EnemyButtonController enemyButtonController;

    public Transform itenListContent;
    public Button itenPrefab;
    public GameObject itenTextPrefab;

    [SerializeField]
    private InventoryBattleList inventory;

    private Item testIten;
    //public int testItenamount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
        for (int i = 0; i < inventory.inventoryList.Count; i++)
        {
            Debug.Log(inventory.inventoryList.Count);
            Debug.Log(inventory.inventoryList[i]);
        }
        */
        enemyButtonController = GameObject.Find("EnemyButtonController").GetComponent<EnemyButtonController>();
        verificateButtonUI = GameObject.Find("ButtonsController").GetComponent<VerificateButtonUI>();
        UpdateItensUI();
    }

    public void UpdateItensUI()
    {
        foreach(Transform child in itenListContent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i<inventory.inventoryList.Count; i++)
        {
            //Nome de item
            testIten = inventory.inventoryList[i];

            if (testIten.quantity > 0)
            {
                Button entry = Instantiate(itenPrefab, itenListContent);
                TMP_Text itenNameText = entry.transform.Find("ItensNameText").GetComponent<TMP_Text>();
                Transform itenNumberList = entry.transform.Find("ItensNumberPanel");
                itenNameText.text = testIten.itemName;

                //Quantidade do item
                GameObject quantityTextGO = Instantiate(itenTextPrefab, itenNumberList);
                TMP_Text quantityText = quantityTextGO.GetComponent<TMP_Text>();
                quantityText.text = testIten.quantity.ToString();

                int index = i;
                entry.onClick.RemoveAllListeners();
                entry.onClick.AddListener(() => {verificateButtonUI.DisactivateItensPanel(); verificateButtonUI.ActivateReturnButton(); enemyButtonController.SelectEnemyButtonsItens(index); });
            }
            else
            {
                inventory.inventoryList.RemoveAt(i);
                i--;
            }
        }
    }

    public void ReduceQuantityIten(int index)
    {
        inventory.inventoryList[index].quantity--;
        UpdateItensUI();
    }

}
