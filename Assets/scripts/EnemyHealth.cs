using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Animator anim;

    [SerializeField] int maximumHealth = 100;
    int currentHealth = 100;

    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;

    CapsuleCollider CapsuleCollider;
    public bool IsDead;
    bool IsSinking;
    public bool destroyOnDeath;

    // Use this for initialization
    void Start()
    {
        currentHealth = maximumHealth;
        anim = GetComponent<Animator>();
    }

    public bool isDead { get{ return currentHealth <= 0; } }

    public int getHealth()
    {
        return currentHealth;
    }

    public int getMaxHealth()
    {
        return maximumHealth;
    }

    public void Damage(int damageValue)
    {
        currentHealth -= damageValue;

        if (currentHealth <= 0)
        {
            if (gameObject.tag != "Player")
            {
                UIScript.UpdateScore(50);
            }
            Destroy(gameObject);

            if (anim)
            {
                anim.SetBool("Dead", true);
            }
            UIScript.UpdateScore(50);
            Destroy(GetComponent<EnemyNavMovement>());
            Destroy(GetComponent<UnityEngine.AI.NavMeshAgent>());
            Destroy(GetComponent<CharacterController>());
            Destroy(GetComponentInChildren<EnemyAttack>());

            GameManager.amountKilled++;
        }
    }
    void Update()
    {
        if (IsSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }
}

