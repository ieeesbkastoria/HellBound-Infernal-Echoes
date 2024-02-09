using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float PlatformSpeed;
    [SerializeField] private Transform postA, postB;
    Vector2 targetPost;
    void Start()
    {
        targetPost = postB.position;
    }
    // Update is called once per frame
    void Update()
    {
       if (Vector2.Distance(transform.position, postA.position) < .1f) targetPost = postB.position;

        if (Vector2.Distance(transform.position, postB.position) < .1f) targetPost = postA.position;

        transform.position = Vector2.MoveTowards(transform.position, targetPost, PlatformSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

    private void OnDrawGizmos() 
    {
    Gizmos.color = Color.red;
    Gizmos.DrawLine(postA.position, postB.position);    
    }
}
