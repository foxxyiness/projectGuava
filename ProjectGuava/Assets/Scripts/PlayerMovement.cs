using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public bool faceRight;
    public float movement;
    public int powerJump = 200;
    public void PlayerMove()
    {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown ("Jump"))
        {
            Jump();
        }

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

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    public void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * powerJump);
    }
    public void FlipPlayer()
    {
        faceRight = !faceRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
