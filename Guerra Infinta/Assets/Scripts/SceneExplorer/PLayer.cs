using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rig;

    float directionHori;
    float directionVert;

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
        rig.linearVelocity = new Vector2(directionHori * speed, directionVert * speed);
        //transform.position = new Vector2(directionHori * speed, directionVert * speed);
    }

    void Move()
    {
        if(Input.GetAxis("Horizontal") > 0f && speed != 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (Input.GetAxis("Horizontal") < 0f && speed != 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }
}