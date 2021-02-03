using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    public bool isDead;
    public int maxHealth = 3;
    public int currentHealth;
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = maxHealth;
        if (gameObject.transform.position.y < -6)
        { 
            isDead = true;
        }

        if (isDead == true)
        {
            currentHealth = currentHealth - 1;
            StartCoroutine("Die");
            SceneManager.LoadScene(1);
        }

        if (currentHealth == 0)
        {
            //Loads death screen :D
            SceneManager.LoadScene(2);
        }
    }
    IEnumerator Die()
    {
        Debug.Log("Player has fallen");
        yield return new WaitForSeconds(2);
        Debug.Log("Player dead");
    }
}
