using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class uiManager : MonoBehaviour
{
    [Header("Script Comms")]

    public Player player;


    [Header("HUD and Values")]

    //Objs
    public TMP_Text gameTimer; //how long remains to complete the current level
    public TMP_Text killCounter; //how many kills the player has recorded


    //Values
    // public float[] levelTimes; //values of each level's beginning timer
    public float timeLeft = 120;




    [Header("XP Bar")]

    //Objs
    public Image xpBar;
    public TMP_Text XPCounter;

    //Values
    public float currentXP = 0f;
    public float maxXP = 100f;
    public float xpChangeAmount = 1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentXP);
        UpdateXPBar();
        UpdateKills();
        UpdateClock();
    }

    #region HUD

    private void UpdateKills()
    {
        killCounter.text = "Kills: " + player.killCount; // Update text dynamically

    }

    void UpdateClock()
    {
        if (timeLeft >= 1)
        {
            timeLeft -= Time.deltaTime;
            UpdateTime(timeLeft);
        }
    }

    void UpdateTime(float currentTime)
    {

        // Convert the time to a readable format (hours, minutes, seconds, and milliseconds)
        int minutes = Mathf.FloorToInt((timeLeft % 3600F) / 60F);
        int seconds = Mathf.FloorToInt(timeLeft % 60F);

        // Format the time into a string
        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        gameTimer.text = formattedTime;

    }



    #endregion

    #region XP Bar


    // Change XP (increase or decrease by amount)

    public void IncreaseXP(float amount)
    {
        //Debug.Log(currentXP);
        currentXP += amount;

        // Stay within set range of 0-Max
        //currentXP = Mathf.Clamp(currentXP, 0, maxXP);
    }

    public void DecreaseXP(float amount)
    {
        currentXP -= amount;

        // Stay within set range of 0-Max
        currentXP = Mathf.Clamp(currentXP, 0, maxXP);
    }

    // Function to update the XP Bar UI
    public void UpdateXPBar()
    {
        // Calculate the fill amount based on currentXP and maxXP
        float fillAmount = currentXP / maxXP;

        // Update the XP bar's fill amount
        xpBar.fillAmount = fillAmount;

        Mathf.RoundToInt(currentXP); //round currentXP to int
        XPCounter.text = currentXP.ToString() + "/100"; // Update the TextMeshPro text
    }
    #endregion

    #region Abilities



    #endregion
}