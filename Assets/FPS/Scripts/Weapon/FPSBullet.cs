using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSBullet : MonoBehaviour
{
    public int damage = 10;
    public float speed = 10f;
    public GameObject effectsPrefab;
    public Transform line;
    private Rigidbody rigid;

    // Start is called before the first frame update
    void Awake()
    {
        // Get component on awake so we dont miss i if it starts disabled
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigid.velocity.magnitude > 0)
        {
            // Rotate the line to face direction of bullet travel
            line.transform.rotation = Quaternion.LookRotation(rigid.velocity);
        }
    }

    private void OnCollisionEnter(Collision col) // gives you an array of collisions
    {
        // Get a contact point from collisoin
        ContactPoint contact = col.contacts[0];
        // Spawn the effect
        //Instantiate(effectsPrefab, contact.point, Quaternion.LookRotation(contact.normal));
        FPSEnemy enemy = col.collider.GetComponent<FPSEnemy>();
        if (enemy)
        {
            enemy.TakeDamage(damage);
        }
        // Destroy the bullet
        Destroy(gameObject);
    }

    public void Fire(Vector3 lineOrigin, Vector3 direction)
    {

        // Ad an instant force to the bullet
        rigid.AddForce(direction * speed, ForceMode.Impulse);
        // Set the line's origin(different from the bullet's starting position) 
        line.transform.position = lineOrigin;
    }
}

