using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject popUp;
    [SerializeField] private Transform target; // Position Icon
    private float timer = 1.0f;
    private bool isActive = false;

    public void Start()
    {
        popUp.SetActive(false);
    }

    public void ShowDamage(int damage)
    {
        isActive = true;
        text.text = damage.ToString();
        popUp.SetActive(true);
        Debug.Log("Showdamage comecou");
    }

    void Update()
    {
        if (!isActive) return;

        // posiciona no inimigo
        text.transform.position = target.position;

        // Conta o tempo
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            timer = 1.0f;
            popUp.SetActive(false);
            isActive = false;
        }
    }
}