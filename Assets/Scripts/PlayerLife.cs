using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public LogicScript logic;
    private Rigidbody2D rb;
    private int Life;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }  

        if (collision.gameObject.CompareTag("Win"))
        {
            logic.GameVictory();
            rb.bodyType = RigidbodyType2D.Static;   
        }
    }

    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

