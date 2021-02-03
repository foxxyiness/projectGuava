using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int speed;
    public int MoveX;

    Health health;
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(MoveX, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(MoveX, 0) * speed;
        if (hit.distance < 0.7f)
        {
            FlipPlayer();
            if(hit.collider.tag == "Player")
            {
               
            }
        }

       

    }

    public void FlipPlayer()
    {
        if (MoveX > 0)
        {
            MoveX = -1;
        } 
        else
        {
            MoveX = 1;
        }
    }
}
