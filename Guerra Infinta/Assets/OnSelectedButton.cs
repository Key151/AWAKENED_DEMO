using UnityEngine;
using UnityEngine.EventSystems;


//IPointerEnterHandler, IPointerExitHandler - É usado para saber se um objeto está com o mouse em cima ---- ISelectHandler, IDeselectHandler - É usado para saber se um botão está selecionado
public class ShowOnSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject enemyHUD;
    [SerializeField] private SpriteRenderer seta;
    private bool selected = false;
    private Animator anim;
    private Color corNormal = Color.white;
    private Color corHighlight = Color.yellow;

    private const string Idle = "Seta Idle";

    private const string Moving = "Seta Animation";

    void Start()
    {
        // Garante que o objeto comece invisiel
        if (enemyHUD != null)
        {
            if (!selected)
            {
                anim = seta.GetComponent<Animator>();
                NormalState();
            }
            
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (enemyHUD != null)
        {
            NormalState();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (enemyHUD != null)
        {
            SelectedState();
            selected = true;
        }
    }

    public void OnClick()
    {
        NormalState();
        //seta.color = (selected ? corNormal : corHighlight);
    }

    public void NormalState()
    {
        enemyHUD.SetActive(false);
        seta.color = corNormal;
        anim.Play(Idle);
    }

    public void SelectedState()
    {
        enemyHUD.SetActive(true);
        seta.color = corHighlight;
        anim.Play(Moving);
    } 




}
