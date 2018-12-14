using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    float nextTimeAttackIsAllowed = 1.0f;

    [SerializeField] float attackDelay = 1.0f;

    [SerializeField] int damageDealt = 5;
    HealthScript playerHealth;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Time.time >= nextTimeAttackIsAllowed)
        {
            HealthScript playerHealth = other.GetComponent<HealthScript>();
            anim.SetTrigger("Attack");

            print("player");
            if (playerHealth)
            {
                playerHealth.Damage(damageDealt);
            }
            nextTimeAttackIsAllowed = Time.time + attackDelay;
        }
    }
}