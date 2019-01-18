using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] GameObject thingToSpawn;
    [SerializeField] float delayBetweenSpawns = 2.0f;
    [SerializeField] float timeOfNextSpawn = 1f;
    int amountToSpawn = 10;
    static int amountSpawned = 1;

    void Update()
    {
        if (Time.time >= timeOfNextSpawn && amountSpawned < amountToSpawn)
        {
            Instantiate(thingToSpawn, transform.position, Quaternion.identity);
            timeOfNextSpawn = Time.time + delayBetweenSpawns;
            amountSpawned++;
        }
    }

    static public void EnemyDie()
    {
        amountSpawned--;
    }
}

