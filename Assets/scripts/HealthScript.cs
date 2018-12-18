using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    [SerializeField] int maximumHealth = 100;
    public int currentHealth = 0;

    [SerializeField]
    private Stat health;

    [SerializeField]
    private Stat energy;

    Animator anim;

    void Start()
    {
        currentHealth = maximumHealth;
        anim = GetComponent<Animator>();
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
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
