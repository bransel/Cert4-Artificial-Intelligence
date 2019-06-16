using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class FPSEnemy : MonoBehaviour
{
    public Transform healthBarParent; // reference to parent to store health bar UI
    public GameObject healthbarUIPrefab; // prefab to spawn in health bar parent
    public Transform healthBarPoint;

    public int maxHealth = 100;
    private int health = 0;
    private Slider healthSlider;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        // spawn healthbar UI into parent and get reference to slider component on clone
        GameObject clone = Instantiate(healthbarUIPrefab, healthBarParent);
        healthSlider = clone.GetComponent<Slider>();
        //set health to max health
        health = maxHealth;

        // get the renderer component from this GameObject
        rend = GetComponent<Renderer>();
        Seek seek = GetComponent<Seek>();
    }

    // Update is called once per frame
    void LateUpdate()

    { 
        // Is the renderer (meshrenderer in this case) is within the camera's view
        if (rend.isVisible )

        {
            healthSlider.gameObject.SetActive(true);
            //update position of health bar
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(healthBarPoint.position); // + offset
            healthSlider.transform.position = screenPosition;
            // update value of slider
        }
        else
        {
            // disable the health slider
            healthSlider.gameObject.SetActive(false);
        }
    }

    void OnDestroy()
    {
        Destroy(healthSlider.gameObject);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        // update value of slider
        healthSlider.value = (float)health / (float)maxHealth; // converts 0-100 to 0-1
        // if health is zero
        if (health < 0)
        {
            // Destroy GameObject

            Destroy(gameObject);
        }


    }
}
