using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    internal static int amountKilled;
    public BarScript playerHealth;
    public Text score;
    public Text playerHealthTxt;
    public Text timeTxt;
    public static bool won;
    public GameObject winPanel;
    public GameObject losePanel;

    void Start()
    {
        winPanel.SetActive(false);
        amountKilled = 0;
        losePanel.SetActive(false);
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > 180)
        {
            won = true;
        }

        if (won == true)
        {
            Time.timeScale = 0;
            winPanel.SetActive(true);
        }
        if (amountKilled > 15)
        {
            EventManager.TriggerEvent("zombiesKilled");
        }
        else if (amountKilled > 30)

        if (GameManager.won == true)
        {
            winPanel.SetActive(true);
        }
    }
}
