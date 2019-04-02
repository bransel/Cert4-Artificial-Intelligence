using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCannon : MonoBehaviour {

    public float speed = 10f; // 
    //private Rigidbody rigid; // Reference to rigidbody
    public ForceMode force;
    public int damage = 20;
    private void Awake()
    {
        // Get reference to Rigidbody
        

    }

   void Start()
    {
        
    }

    // Fire's this bullet in a given direction (using defined speed)
    public void Fire(Vector3 direction)
    {
        Rigidbody rigid = GetComponent<Rigidbody>();
        // Add force in the given direction by speed
        rigid.AddForce(direction * speed, force);
    }

    void OnTriggerEnter(Collider collision)
    {
        
        TowerEnemyTest enemy = collision.GetComponent<TowerEnemyTest>();

        Debug.Log("HIT");
        if (enemy)
        {
            enemy.TakeDamage(damage);

            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
