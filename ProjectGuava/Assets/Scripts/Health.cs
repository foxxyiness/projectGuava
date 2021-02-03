using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Vector2 respawn;
    public bool isDead;
    public int maxHealth = 3;
    public int currentHealth;
   
    void Start()
    {
        isDead = false;
        currentHealth = maxHealth;
    }

    
    void Update()
    {
        if (gameObject.transform.position.y < -6)
        { 
            isDead = true;
        }

        if (isDead == true)
        {
            currentHealth = currentHealth - 1;
            StartCoroutine("Die");
            Respawn();
            isDead = false;
        }

        if (currentHealth == 0)
        {
            //Loads death screen :D
            SceneManager.LoadScene(2);
        }
    }

    public void Respawn()
    {
        transform.position = respawn; ;
    }
    IEnumerator Die()
    {
        Debug.Log("Player has fallen");
        yield return new WaitForSeconds(2);
        Debug.Log("Player dead");
    }
}
