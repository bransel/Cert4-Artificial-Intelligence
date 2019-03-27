﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class Cannon : Tower
{

    public Transform orb;
    public float lineDelay = .2f;
    public LineRenderer line;

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
    }

    IEnumerator DisableLine()
    {
        yield return new WaitForSeconds(lineDelay);
        line.enabled = false; 
    }

    public override void Aim(TowerEnemy e)
    {
        // Get orb to look at enemy
        orb.LookAt(e.transform);
        // Create line from orb to enemy
        line.SetPosition(0, orb.position);
        line.SetPosition(1, e.transform.position);
    }

    public override void Attack(TowerEnemy e)
    {
        // Enable the line
        line.enabled = true;
        // Deal damage to enemy
        e.TakeDamage(damage);
        // Run coroutine to disbale hte line on a delay
        StartCoroutine(DisableLine());
    }
}