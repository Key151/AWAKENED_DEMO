using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItensUI : MonoBehaviour
{

    public Transform itenListContent;
    public Button itenPrefab;
    public GameObject itenTextPrefab;
    public GameObject itensImagePrefab;

    [Header("Classes")]
    [SerializeField] private Inventory inventory;
    [SerializeField] private VerificateButtonUI verificateButtonUI;
    [SerializeField] private EnemyButtonController enemyButtonController;

    private Item testIten;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
                Transform itensImagePanel = entry.transform.Find("ItensImagePanel");
                itenNameText.text = testIten.ItemName();

                //Quantidade do item
                GameObject quantityTextGO = Instantiate(itenTextPrefab, itenNumberList);
                TMP_Text quantityText = quantityTextGO.GetComponent<TMP_Text>();
                quantityText.text = testIten.quantity.ToString();

                GameObject itensImagemGO = Instantiate(itensImagePrefab, itensImagePanel);
                Image itensImagem = itensImagemGO.GetComponent<Image>();
                itensImagem.sprite = testIten.icon;

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
