using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Animator anim;

    [SerializeField] GameObject bloodhit;

    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    float nextTimeAttackIsAllowed = 1.0f;

    [SerializeField] float attackDelay = 1.0f;

    [SerializeField] int damageDealt = 5;
    EnemyHealth playerHealth;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Time.time >= nextTimeAttackIsAllowed)
        {
            EnemyHealth playerHealth = other.GetComponent<EnemyHealth>();
            anim.SetTrigger("Attack");
            playerHealth.Damage(damageDealt);

            Vector3 hitDirection = (transform.root.position - other.transform.position).normalized;
            Vector3 hitEffectPos = other.transform.position + (hitDirection * 0.01f) + (Vector3.up * 1.5f);
            Quaternion hitEffectRoatation = Quaternion.FromToRotation(Vector3.forward, hitDirection);
            Instantiate(bloodhit, hitEffectPos, hitEffectRoatation);

            print("player");
            if (playerHealth)
            {
                playerHealth.Damage(damageDealt);
            }
            nextTimeAttackIsAllowed = Time.time + attackDelay;
        }
    }
}