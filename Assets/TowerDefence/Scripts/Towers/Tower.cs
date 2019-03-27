using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public int damage = 10;
    //range : float
    public float attackRate = 1f;
    public float attackRange = 2f;

    protected TowerEnemy currentEnemy;

    private float attackTimer = 0f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        // Draw the attack sphere around Tower
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    // Aims at a given enemy every frame
    public virtual void Aim(TowerEnemy e)
    {

        print("I am aiming at '" + e.name + "'");
    }


    //Attacks at a given enemy only when 'attacking'
    public virtual void Attack(TowerEnemy e)
    {
        print("I am attacking at '" + e.name + "'");
    }

    void DetectEnemies()
    {
        // reset current enemy
        currentEnemy = null;
        // Perform OverlapSphere
        Collider[] hits = Physics.OverlapSphere(transform.position, attackRange);
        // Loop through everything we hit

        foreach (var hit in hits)
        {
            TowerEnemy enemy = hit.GetComponent<TowerEnemy>();
            if (enemy)
            {
                // Set current enemy to that one
                currentEnemy = enemy;
            }
        }
    }

    // Protected - Accessible to Cannon / Other Tower Classes
    // Virtual - Able to change what this function does in derived classes
    protected virtual void Update()
    {

        // Detect enemies before performing attack logic
        DetectEnemies();

        // Count up the timer
        attackTimer += Time.deltaTime;
        // if there's an enemy
        if (currentEnemy)
        {
            // Aim at the enemy
            Aim(currentEnemy);
            // Is attack timer ready?
            if (attackTimer >= attackRate)
            {
                // attack the enemy!
                Attack(currentEnemy);
                // Reset timer
                attackTimer = 0f;
            }
        }
    }
}

    //Fire(): Void
       
  