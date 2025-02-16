using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class uiManager : MonoBehaviour
{

    [Header("Abilities")]
    
    //Objs

    //Values


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
        UpdateXPBar();  
    }

    #region XP Bar


    // Change XP (increase or decrease by amount)

    public void IncreaseXP(float amount)
    {
        currentXP += amount;

        // Stay within set range of 0-Max
        currentXP = Mathf.Clamp(currentXP, 0, maxXP);
    }

    public void DecreaseXP(float amount)
    {
        currentXP -= amount;

        // Stay within set range of 0-Max
        currentXP = Mathf.Clamp(currentXP, 0, maxXP);
    }

    // Function to update the XP Bar UI
    private void UpdateXPBar()
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