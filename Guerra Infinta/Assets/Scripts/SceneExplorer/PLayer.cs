using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class Player : MonoBehaviour
{
    private float speedx;
    private float speedy;
    private float speed = 0.2f;
    public float speedControl = 1;
    public Rigidbody2D rig;

    private float directionHori;
    private float directionVert;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        directionHori = Input.GetAxis("Horizontal");
        directionVert = Input.GetAxis("Vertical");
        Move();

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        //}
    }

    // � chamado pela f�sica
    private void FixedUpdate()
    {
        //Velocidade X
        speedx *= 0.99f;
        if(speedx > 0)
        {
            speedx -= 0.1f;
        }else if(speedx < 0)
        {
            speedx += 0.1f;
        }
        directionHori += speedx;

        //Velocidade Y
        speedy *= 0.99f;
        if (speedy > 0)
        {
            speedy -= 0.1f;
        }
        else if (speedy < 0)
        {
            speedy += 0.1f;
        }
        directionVert += speedy;


        //Movimento
        rig.linearVelocity = new Vector2(directionHori * speedControl, directionVert * speedControl);
    }

    void Move()
    {
        if(Input.GetAxis("Horizontal") > 0f)
        {
            speedx += speed;
            if(speedx > 5)
            {
                speedx = 5;
            }
            if(speedControl != 0)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
        }

        if (Input.GetAxis("Horizontal") < 0f)
        {
            speedx -= speed;
            if(speedx < -5)
            {
                speedx = -5;
            }
            if (speedControl != 0)
            {
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
        }

        if (Input.GetAxis("Vertical") > 0f)
        {
            speedy += speed;
            if(speedy > 5)
            {
                speedy = 5;
            }
        }

        if (Input.GetAxis("Vertical") < 0f)
        {
            speedy -= speed;
            if (speedy < -5)
            {
                speedy = -5;
            }
        }
    }
}