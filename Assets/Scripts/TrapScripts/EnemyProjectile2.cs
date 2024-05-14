using UnityEngine;

public class EnemyProjectile2 : MonoBehaviour
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
    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerLife>().TakeDamage(damage);
            //if (anim != null) anim.SetTrigger("explode"); //When the object is a fireball explode it
        }
        coll.enabled = false;
        gameObject.SetActive(false); //When this hits any object deactivate arrow
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

}