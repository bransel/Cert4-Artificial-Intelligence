using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LineRenderer))]

public class TestCannon : TestTower
{

    public Transform orb;
    public float lineDelay = .2f;
    public LineRenderer line;
    public GameObject Range;

    void Reset()
    {
        line = GetComponent<LineRenderer>();
    }

    protected override void Update()
    {
      

        base.Update();
        // if currentenemy is null
        if (currentEnemy == null)
        {
            // disable the line
            line.enabled = false;
        }
        Range = transform.Find("Range").gameObject;
        Range.transform.localScale = new Vector3(attackRange/2, 0.01f, attackRange/2);
    }

    IEnumerator DisableLine()
    {
        yield return new WaitForSeconds(lineDelay);
        line.enabled = false; 
    }

    public override void Aim(TowerEnemyTest e)
    {
        // Get orb to look at enemy
        orb.LookAt(e.transform);
        // Create line from orb to enemy
        line.SetPosition(0, orb.position);
        line.SetPosition(1, e.transform.position);
    }

    public override void Attack(TowerEnemyTest e)
    {
        // Enable the line
        line.enabled = true;
        // Deal damage to enemy
        e.TakeDamage(damage);
        // Run coroutine to disbale hte line on a delay
        StartCoroutine(DisableLine());
    }
}