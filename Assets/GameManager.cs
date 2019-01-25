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
        losePanel.SetActive(false);
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > 5)
        {
            won = true;
        }

        if (GameManager.won == true)
        {
            winPanel.SetActive(true);
        }
    }
}
