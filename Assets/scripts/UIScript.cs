using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class UIScript : MonoBehaviour
{

    public HealthScript healthScript;
    public Text healthTxt;
    public BarScript healthBar;
    public Text scoreNum;
    public Text timeNum;
    public GameObject losePanel;
    static int score;

    // Use this for initialization
    void Start()
    {

        GameManager manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        healthBar = manager.playerHealth;
        healthTxt = manager.playerHealthTxt;
        scoreNum = manager.score;
        timeNum = manager.timeTxt;

        healthBar.MaxValue = healthScript.getMaxHealth();
        healthBar.Value = healthScript.getHealth();
        healthTxt.text = "Health: " + healthScript.getHealth();
    }

    IEnumerator UpdateUI()
    {
        healthBar.Value = healthScript.getHealth();
        healthTxt.text = "Health: " + healthScript.getHealth();
        timeNum.text = "" + (int)Time.time;
        scoreNum.text = score + "";

        if (healthScript.IsDead)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0;
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("UpdateUI");
    }
    public static void UpdateScore(int amount)
    {
        score += amount;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.Value = healthScript.getHealth();
        healthTxt.text = "Health: " + healthScript.getHealth();
        timeNum.text = "" + (int)Time.time;
        scoreNum.text = score + "";

        if (healthScript.IsDead)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
