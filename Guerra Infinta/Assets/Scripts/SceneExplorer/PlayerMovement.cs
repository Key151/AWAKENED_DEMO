using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    public float speedControl = 1;
    [SerializeField] private float recordTimer = 0f;
    private float recordInterval = 0.05f;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 moveInput;
    public List<Vector2> positionHistory = new List<Vector2>();
    public List<Vector2> inputHistory = new List<Vector2>();
    //private string walk = "isWalking";
    private string walk = "Walk";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseController.IsGamePaused)
        {
            rb.linearVelocity = Vector2.zero;
            animator.SetBool(walk, false);
            return;
        }

        recordTimer += Time.deltaTime;
        if (recordTimer >= recordInterval && rb.linearVelocity.magnitude > 0)
        {
            positionHistory.Insert(0, transform.position);
            inputHistory.Insert(0, moveInput);
            recordTimer = 0f;
            if (positionHistory.Count > 50)
            {
                positionHistory.RemoveAt(positionHistory.Count - 1);
            }
            if (inputHistory.Count > 50)
            {
                inputHistory.RemoveAt(inputHistory.Count - 1);
            }
        }

        rb.linearVelocity = moveInput * moveSpeed;
        animator.SetBool(walk, rb.linearVelocity.magnitude > 0);
        if (animator.GetBool(walk))
        {
            if (moveInput.x > 0)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
            else if (moveInput.x < 0)
            {
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
        }
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            animator.SetBool(walk, false);
            //animator.SetFloat("LastInputX", moveInput.x);
            //animator.SetFloat("LastInputY", moveInput.y);
        }
        moveInput = context.ReadValue<Vector2>();
        //animator.SetFloat("InputX", moveInput.x);
        //animator.SetFloat("InputY", moveInput.y);
    }

    ///////////////////////////////////////////////////
}
