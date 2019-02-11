using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achivement : MonoBehaviour
{
    public GameObject deathBadge;
    public GameObject SurviveBadge;

    // Start is called before the first frame update
    void Start()
    {
        deathBadge.SetActive(fasle);
    }

    void OnEnable()
    {
        EventManager.StartListening("zombiesKilled", revelDeathBadge);
    }

    void OnDisable()
    {
        EventManager.StopListening("zombiesKilled", revelDeathBadge);
    }

    void revelDeathBadge()
    {
        deathBadge.SetActive(true);
    }
}