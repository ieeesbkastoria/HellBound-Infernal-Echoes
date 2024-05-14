using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    PlayerLife playerLife;
    public Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
             Debug.Log("Collision with player");
             anim.SetBool("Collision with player", true);
             playerLife.UpdateCheckpoint(transform.position);
        }
    }

    private void NonCollision()
    {
        Debug.Log("Non Collision with player");
        anim.SetBool("Collision with player", false);
    }
}
