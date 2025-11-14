using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class Follow : MonoBehaviour
{

    public float speed;
    public int followDelay = 5;
    public  float StoppingDistance;
    private bool isWalking;
    private Vector2 moveInput;
    private Transform Target;
    private Animator animator;
    private Rigidbody2D rb;

    private float lastInputX;
    private float lastInputY;
    private bool hasStopped;

    PlayerMovement playerMovement;

    //private string walk = "isWalking";
    private string walk = "Walk";

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Menino").GetComponent<PlayerMovement>();
        //playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseController.IsGamePaused)
        {
            isWalking = false;
            animator.SetBool(walk, isWalking);
            return;
        }
        Move();
        animator.SetBool(walk, isWalking);
    }

    private void Move()
    {

        if (playerMovement.positionHistory.Count > followDelay)
        {
            Vector2 targetPosition = playerMovement.positionHistory[followDelay];
            float distance = Vector2.Distance(transform.position, targetPosition);
            Vector2 direction = targetPosition - (Vector2)transform.position;

            if (distance > 0.01f)
            {
                isWalking = true;
                moveInput = playerMovement.inputHistory[followDelay];
                //animator.SetFloat("InputX", moveInput.x);
                //animator.SetFloat("InputY", moveInput.y);
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                if (direction.x > 0)
                {
                    transform.eulerAngles = new Vector3(0f, 0f, 0f);
                }
                else if (direction.x < 0)
                {
                    transform.eulerAngles = new Vector3(0f, 180f, 0f);
                }
            }
            else
            {
                isWalking = false;
                animator.SetBool(walk, isWalking);
                //animator.SetFloat("LastInputX", moveInput.x);
                //animator.SetFloat("LastInputY", moveInput.y);
            }
        }
        else
        {
            isWalking = false;
        }
    }
}
