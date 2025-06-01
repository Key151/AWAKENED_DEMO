using TMPro;
using UnityEngine;

public class ItensUI : MonoBehaviour
{

    public Transform itenListContent;
    public GameObject itenPrefab;
    public GameObject itenTextPrefab;

    public Item testIten;
    public int testItenamount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    public void UpdateItensUI()
    {
        foreach(Transform child in itenListContent)
        {
            Destroy(child.gameObject);
        }

        /*foreach(var iten in testIten)
        {
            GameObject entry = Instantiate(itenPrefab, itenListContent);
            TMP_Text itenNameText = entry.transform.Find("ItensNameText").GetComponent<TMP_Text>();
            Transform itenNumberList = entry.transform.Find("ItensNumberText");

            itenNameText.text = iten.iten.Name;

            //foreach(var itenNumber)
        }*/
    }
}
