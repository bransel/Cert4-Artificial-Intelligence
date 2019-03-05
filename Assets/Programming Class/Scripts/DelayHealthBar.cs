using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelayHealthBar : MonoBehaviour
{

    [Header("Health")]
    public float maxHealth;
    public float curHealth;
    public float delayHealth;


    [Header("HealthStuff")]
    public float speedDrop;

    // reference to curhealth slider, delayhealth slider, foreground/curhealth and delayhealth/background fill of slider 
    public Slider curHealthSlider;
    public Slider delHealthSlider;
    public Image curHealthFill;
    public Image curHealthDelay;




    void Update()
    {
        delBar();
    }

    void delBar()
    {
        // health slider value updates when current health changes but needs to stay between 0 and max
        curHealthSlider.value = Mathf.Clamp01(curHealth / maxHealth);
        // If our current health is < delay current health, then bring our cur or del? health down over speed time
        // delay slider's value to be set to the delay health amount between it's min and max
        if (curHealth < delayHealth)


        {
            // deltatime will make the speed drop happen in real time 
            delayHealth -= speedDrop * Time.deltaTime;
            delHealthSlider.value = Mathf.Clamp01(delayHealth / maxHealth);

        }


        // to manage the health bar , make sure foreground fill is disabled upon death , and enabled upon revive
        if (curHealth <= 0 && curHealthFill.enabled)

        {
            Debug.Log("Dead");
            curHealthFill.enabled = false;
        }
        else if (!curHealthFill.enabled && curHealth > 0)
        {
            Debug.Log("Revive");
            curHealthFill.enabled = enabled;
        }
        // once delaybar is empty turn off delayhealth bar fill, upon revive turn on fill and make sure delay health and slider value are full
        if (delayHealth <= 0 && curHealthDelay.enabled)

        {

            curHealthDelay.enabled = false;
        }
        else if (!curHealthDelay.enabled && curHealth > 0)
        {
            
            curHealthDelay.enabled = enabled;
            delayHealth = maxHealth;
            delHealthSlider.value = 1;
        }

    }
}
