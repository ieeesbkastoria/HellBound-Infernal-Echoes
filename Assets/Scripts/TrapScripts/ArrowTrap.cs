using Unity.VisualScripting;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float AttackCooldown;
    [SerializeField] private Transform ArrowPoint;
    [SerializeField] private GameObject[] Arrows;
    private float CooldownTimer;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Attack()
    {
        Arrows[FindArrow()].transform.position = ArrowPoint.position;
        Arrows[FindArrow()].GetComponent<EnemyProjectile2>().ActivateProjectile();   
    }

    private int FindArrow()
    {
        for (int i = 0; i < Arrows.Length; i++)
        {
            if (!Arrows[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private void Update()
    {
        CooldownTimer += Time.deltaTime;

        if (CooldownTimer >= AttackCooldown)
        {
            CooldownTimer = 0;
            anim.SetTrigger("Fire");
        }
    }
}
