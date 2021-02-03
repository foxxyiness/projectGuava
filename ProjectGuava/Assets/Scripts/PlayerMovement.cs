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
        PlayerRaycast();
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
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if (col.gameObject.tag == "Victory")
        {
            SceneManager.LoadScene(4);
        }
    }

 

    public void PlayerRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit != null && hit.collider != null && hit.distance < 1.0f && hit.collider.tag == "Enemy")
        {
            Debug.Log("hi");
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            hit.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
            hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            hit.collider.gameObject.GetComponent<Enemy>().enabled = false;
            //Destroy(hit.collider.gameObject);
        }
        if (hit != null && hit.collider != null && hit.distance < 0.5f && hit.collider.tag != "Enemy")
        {
            isGrounded = true;
        }
    }
}
