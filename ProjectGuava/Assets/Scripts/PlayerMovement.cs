using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public bool faceRight;
    public float movement;
    public int powerJump = 200;
    public bool isGrounded;
    public void PlayerMove()
    {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown ("Jump") && isGrounded == true)
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
        isGrounded = false;
    }
    public void FlipPlayer()
    {
        faceRight = !faceRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Player has collided with " + col.collider.name); 
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
