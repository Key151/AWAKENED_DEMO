using UnityEngine;
using UnityEngine.EventSystems;

public class ShowOnSelect : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public GameObject enemyHUD;

    void Start()
    {
        // Garante que o objeto começa invisível
        if (enemyHUD != null)
            enemyHUD.SetActive(false);
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (enemyHUD != null)
            enemyHUD.SetActive(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (enemyHUD != null)
            enemyHUD.SetActive(false);
    }
}
