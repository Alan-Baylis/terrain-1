using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    [SerializeField] int maximumHealth = 100;
    public int currentHealth = 100;

    [SerializeField]
    private Stat health;

    [SerializeField]
    private Stat energy;

    Animator anim;
    public new Renderer renderer;

    void Start()
    {
        currentHealth = maximumHealth;
        anim = GetComponent<Animator>();
        renderer = GetComponentInChildren<Renderer>();
    }

    private void Awake()
    {
        health.Initialize();
        energy.Initialize();
    }

    public bool IsDead { get { return currentHealth <= 0; } }

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
        anim.SetTrigger("Flinch");

        if (currentHealth <= 0)
        {
            if (gameObject.tag != "Player")
            {
                SpawnScript.EnemyDie();
            }
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if (IsDead && !renderer.isVisible)
        {
            Destroy(gameObject);
            GameManager.amountKilled++;
        }
    }
}