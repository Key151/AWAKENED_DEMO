using UnityEngine;

public class BlackScreen : MonoBehaviour
{

    private Animator animator;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("SaveSystem").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    void Update()
    {
        
    }

    public void StartAnimatorBS()
    {
        animator.enabled = true;
        //this.gameObject.SetActive(false);
    }

    public void EndAnimationBS()
    {
        this.gameObject.SetActive(false);
    }

}
