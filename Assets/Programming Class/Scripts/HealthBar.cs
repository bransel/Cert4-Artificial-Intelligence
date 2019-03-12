using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    //reference to player's maximum health and current health
    [Header("Health")]

    //range slider for max health in the inspector UI
    // [Range(0, 100f)]
    public float maxHealth; 
    public float curHealth;

    [Header("Reference to UI elements")]
    //reference to slider
    public Slider healthSlider;
    //reference to the fill colour of the slider
    public Image healthFill;

    // Start is called before the first frame update


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

      
        
        ManageHealthBar();

    }

    void ManageHealthBar()
    {
        // clamp01 does one value between 0 and 1 so curHealth/maxHealth returns a percentage for health. 
        //The slider value automatically is between 0 and 1 so it just converts it from the clamps from the health variables.  
        healthSlider.value = Mathf.Clamp01(curHealth / maxHealth);

        // makes the health fill disappear because it doesn't go away when value = 0 
        if (curHealth <= 0 && healthFill.enabled)

        {
            Debug.Log("Dead");
            healthFill.enabled = false;
        }

        else if (!healthFill.enabled && curHealth > 0)
        {
            Debug.Log("Revive");
            healthFill.enabled = enabled;
        }
    }
}
