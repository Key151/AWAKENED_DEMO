using UnityEngine;
using UnityEngine.EventSystems;


//IPointerEnterHandler, IPointerExitHandler - É usado para saber se um objeto está com o mouse em cima ---- ISelectHandler, IDeselectHandler - É usado para saber se um botão está selecionado
public class ShowOnSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
                //Debug.Log("Inicio-1");
            }
            //Debug.Log("Inicio");
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (enemyHUD != null)
        {
            enemyHUD.SetActive(false);
            //Debug.Log("Selecionado");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (enemyHUD != null)
        {
            enemyHUD.SetActive(true);
            selected = true;
            //Debug.Log("Deselecionado");
        }
    }

    public void OnClick()
    {
        enemyHUD.SetActive(false);
    }


}
