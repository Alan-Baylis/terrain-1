using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healPickup : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    void OnTriggerEnter(Collider collider)
    {
        print("pick up " + collider.gameObject.tag);
        if (collider.CompareTag("Player"))
        {
            EnemyHealth health = collider.gameObject.GetComponent<EnemyHealth>();
            if (health != null)
            {
                health.Damage(-50);
            }
        }
    }
}
  