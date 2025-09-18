using UnityEngine;

public class BlackScreen : MonoBehaviour
{

    private Animator animator;

    void Start()
    {
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
