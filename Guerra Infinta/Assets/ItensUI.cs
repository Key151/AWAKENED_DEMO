using TMPro;
using UnityEngine;

public class ItensUI : MonoBehaviour
{

    public Transform itenListContent;
    public GameObject itenPrefab;
    public GameObject itenTextPrefab;

    [SerializeField]
    private InventoryList inventory;

    private Item testIten;
    //public int testItenamount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Debug.Log(inventory.inventoryList.Count);
            Debug.Log(inventory.inventoryList[i]);
        }

        UpdateItensUI();
    }

    // Update is called once per frame
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
            GameObject entry = Instantiate(itenPrefab, itenListContent);
            TMP_Text itenNameText = entry.transform.Find("ItensNameText").GetComponent<TMP_Text>();
            Transform itenNumberList = entry.transform.Find("ItensNumberPanel");
            itenNameText.text = testIten.itemName;

            //Quantidade do item
            GameObject quantityTextGO = Instantiate(itenTextPrefab, itenNumberList);
            TMP_Text quantityText = quantityTextGO.GetComponent<TMP_Text>();
            quantityText.text = testIten.quantity.ToString();

        }
    }
}
