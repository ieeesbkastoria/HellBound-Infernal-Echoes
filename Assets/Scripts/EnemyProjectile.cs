using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float ResetTime;
    private float lifetime;
   public void ActivateProjectile()
   {
        lifetime = 0;
        gameObject.SetActive(true);
   }

   private void Update()
   {
        float MovementSpeed = Speed * Time.deltaTime;
        transform.Translate(MovementSpeed, 0 , 0);

        lifetime += Time.deltaTime;
        if (lifetime > ResetTime)
            gameObject.SetActive(false);
   }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        //base.OnTriggerEnter2D(Collision);
        gameObject.SetActive(false);
    }
}
