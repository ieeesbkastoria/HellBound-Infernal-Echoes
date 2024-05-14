using UnityEngine;
using System.Collections;

public class EnemyDeactivate: MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    
    [Header("Kabbom")]
    public float FieldOfImpact;
    public float force;
    public LayerMask LayerToHit;
    public void _Die()
    {
        //Deactivate all attached component classes
        foreach (Behaviour component in components)
             component.enabled = false;
    }

    public void _Awake()
    {
        //Deactivate all attached component classes
        foreach (Behaviour component in components)
             component.enabled = true;
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void Activate()
    {
        gameObject.SetActive(true);
    }

    void explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position,FieldOfImpact,LayerToHit);

        foreach(Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
    }

    private void OnDrawGizmosSelected() 
    {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(transform.position,FieldOfImpact);  
    }

}
