using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float AttackCooldown;
    [SerializeField] private Transform ArrowPoint;
    [SerializeField] private GameObject[] Arrows;
    private float CooldownTimer;

    private void Attack()
    {
        CooldownTimer = 0;

        Arrows[FindArrow()].transform.position = ArrowPoint.position;
        Arrows[FindArrow()].GetComponent<EnemyProjectile>().ActivateProjectile();

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
        Attack();
    }
}
