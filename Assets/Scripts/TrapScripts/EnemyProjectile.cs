using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;

    private float lifetime;
    private Animator anim;
    private CircleCollider2D coll;
    
    private bool hit;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<CircleCollider2D>();
    }

    public void ActivateProjectile()
    {
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerLife>().TakeDamage(damage);
        }
        coll.enabled = false;
        gameObject.SetActive(false); //When this hits any object deactivate arrow
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

}