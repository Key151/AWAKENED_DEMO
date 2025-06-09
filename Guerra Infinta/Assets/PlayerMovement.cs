using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speedx;
    [SerializeField] private float speedy;
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float speedControl = 1;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseController.IsGamePaused)
        {
            speedControl = 0;
        }
        else
        {
            speedControl = 1;
        }
        //rb.linearVelocity = new Vector2(speedx, speedy);
        rb.linearVelocity = moveInput * moveSpeed * speedControl;
        //rb.linearVelocity = moveInput;
        ChangeDirection(rb.linearVelocity.x);
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        //Movimento Horizontal
        /*if (moveInput.x > 0)
        {
            moveInput.x += moveSpeed;
            if (moveInput.x < 5)
            {
                moveInput.x = 5;
            }

        }else if (moveInput.x < 0)
        {
            moveInput.x -= moveSpeed;
            if (moveInput.x < -5)
            {
                moveInput.x = -5;
            }

        }*/

        //Movimento Vertical
        /*if (moveInput.y > 0)
        {
            moveInput.y += moveSpeed;
            if (moveInput.y < 5)
            {
                moveInput.y = 5;
            }

        }
        else if (moveInput.y < 0)
        {
            moveInput.y -= moveSpeed;
            if (moveInput.y < -5)
            {
                moveInput.y = -5;
            }
        }*/

        //moveInput.x *= .99f;
        //moveInput.y *= .99f;

    }

    public void ChangeDirection(float direction)
    {
        if (direction > 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }else if (direction < 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }
}
