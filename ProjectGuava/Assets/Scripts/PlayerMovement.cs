using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public bool faceRight;
    public float movement;
    public int powerJump = 1000;
    public void PlayerMove()
    {
        movement = Input.GetAxis("Horizontal");

        if (movement < 0.0f && faceRight == false)
        {
            FlipPlayer();
        }
        else if (movement > 0.0f && faceRight == true)
        {
            FlipPlayer();
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(movement * speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump()
    {

    }
    public void FlipPlayer()
    {

    }
}
