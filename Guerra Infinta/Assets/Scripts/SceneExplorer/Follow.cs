using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    public float speed;
    public  float StoppingDistance;
    private Transform Target;
    private Animator animator;

    private float lastInputX;
    private float lastInputY;
    private bool hasStopped;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseController.IsGamePaused)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("InputX", lastInputX);
            animator.SetFloat("InputY", lastInputY);
            return;
        }
        Move();
    }

    private void Move()
    {

        Vector2 direction = (Target.position - transform.position).normalized;

        if(direction.magnitude > 0f)
        {
            lastInputX = direction.x;
            lastInputY = direction.y;
        }

        if(!hasStopped)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
            float threshold = 0.5f;
            float inputX = Mathf.Abs(direction.x) < threshold ? 0 : direction.x;
            float inputY = Mathf.Abs(direction.y) < threshold ? 0 : direction.y;
            animator.SetFloat("InputX", inputX);
            animator.SetFloat("InputY", inputY);
            animator.SetBool("isWalking", true);
        }
            

        if (Vector2.Distance(transform.position, Target.position) < StoppingDistance)
        {
            Stop();
        }
        else
        {
            hasStopped = false;
        }
        
    }

    private void Stop()
    {
        hasStopped = true;
        animator.SetBool("isWalking", false);
        animator.SetFloat("LastInputX", lastInputX);
        animator.SetFloat("LastInputY", lastInputY);
    }
}
