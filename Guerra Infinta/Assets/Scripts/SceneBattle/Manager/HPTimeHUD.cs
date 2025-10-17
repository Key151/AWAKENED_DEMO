using UnityEngine;
using TMPro;

public class DamageText : ShowIcon
{
    [SerializeField] private TextMeshProUGUI text;
    
    public void ShowDamage(int damage)
    {
        isActive = true;
        text.text = damage.ToString();
        popUp.SetActive(true);
        Debug.Log("Showdamage comecou");
    }
}