using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHP : MonoBehaviour {
    public int maxHealth = 100;
    private float health = 0;

    // Use this for initialization
    void Start () {
        health = maxHealth;
    }
	
	// Update is called once per frame
	void Update () {
        
}
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)


        {
            Destroy(gameObject);
        }
    }
}
