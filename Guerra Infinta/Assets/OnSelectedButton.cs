using UnityEngine;
using UnityEngine.EventSystems;

public class ShowOnSelect : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public GameObject enemyHUD;
    private bool selected = false;

    void Start()
    {
        // Garante que o objeto comece invisiel
        if (enemyHUD != null)
        {
            if (!selected)
            {
                enemyHUD.SetActive(false);
                Debug.Log("Inicio-1");
            }
            Debug.Log("Inicio");
        }
            
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (enemyHUD != null)
        {
            enemyHUD.SetActive(false);
            Debug.Log("Selecionado");
        }
    }
    public void OnSelect(BaseEventData eventData)
    {
        if (enemyHUD != null)
        {
            enemyHUD.SetActive(true);
            selected = true;
            Debug.Log("Deselecionado");
        }

    }

}
