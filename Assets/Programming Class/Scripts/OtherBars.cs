using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherBars : MonoBehaviour
{

    //reference to player's mana
    [Header("Mana")]

    //range slider for max mana in the inspector UI
    // [Range(0, 100f)]
    public float maxMana;
    public float curMana;

    [Header("Reference to UI elements")]
    //reference to slider
    public Slider manSlide;
    //reference to the fill colour of the slider
    public Image manFill;

    [Header("Stamina")]
    public float maxStam;
    public float curStam;

    [Header("Reference to UI elements")]
    //reference to slider
    public Slider StamSlide;
    //reference to the fill colour of the slider
    public Image StamFill;

    [Header("EXP")]
    public float exP;
    public float curXp;

    [Header("Reference to UI elements")]
    //reference to slider
    public Slider xpSlider;
    //reference to the fill colour of the slider
    public Image xpFill;

    // Start is called before the first frame update


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



        ManageMana();
        ManageStamina();
        ManageXp();




    }

    void ManageMana()
    {
        // clamp01 does one value between 0 and 1 so curHealth/maxHealth returns a percentage for health. 
        //The slider value automatically is between 0 and 1 so it just converts it from the clamps from the health variables.  
        manSlide.value = Mathf.Clamp01(curMana / maxMana);

        // makes the health fill disappear because it doesn't go away when value = 0 
        if (curMana <= 0 && manFill.enabled)

        {
            Debug.Log("Out of Mana");
            manFill.enabled = false;
        }

        else if (!manFill.enabled && curMana > 0)
        {

            manFill.enabled = enabled;
        }
    }

    void ManageStamina()
    {
        // clamp01 does one value between 0 and 1 so curHealth/maxHealth returns a percentage for health. 
        //The slider value automatically is between 0 and 1 so it just converts it from the clamps from the health variables.  
        StamSlide.value = Mathf.Clamp01(curStam / maxStam);

        // makes the health fill disappear because it doesn't go away when value = 0 
        if (curStam <= 0 && StamFill.enabled)

        {
            Debug.Log("Out of Stamina");
            StamFill.enabled = false;
        }

        else if (!manFill.enabled && curStam > 0)
        {

            StamFill.enabled = enabled;
        }
    }

    void ManageXp()
    {
        // clamp01 does one value between 0 and 1 so curHealth/maxHealth returns a percentage for health. 
        //The slider value automatically is between 0 and 1 so it just converts it from the clamps from the health variables.  
        xpSlider.value = Mathf.Clamp01(curXp / exP);

        // makes the health fill disappear because it doesn't go away when value = 0 
        if (curXp <= 0 && xpFill.enabled)

        {
            Debug.Log("Out of Stamina");
            xpFill.enabled = false;
        }

        else if (!xpFill.enabled && exP > 0)
        {

            xpFill.enabled = enabled;
        }
    }
}
