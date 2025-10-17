using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackScreen : MonoBehaviour
{

    private Animator animator;

    private string fadeIN = "FadeIn";
    private string fadeOUT = "FadeOut";

    [SerializeField] private string Scene;

    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.enabled = true;
    }

    public void StartFadeOut() //De Transparente Fica Preto
    {
        animator.Play(fadeOUT);
    }

    public void StartFadeIn() //De Preto Fica Transparente
    {
        animator.Play(fadeIN);
    }

    public void EndAnimationFadeIn()
    {
        this.gameObject.SetActive(false);
    }

    public void EndAnimationFadeOut()
    {
        if(!string.IsNullOrEmpty(Scene))
        {
            SceneManager.LoadScene(Scene);
        }
    }
}
