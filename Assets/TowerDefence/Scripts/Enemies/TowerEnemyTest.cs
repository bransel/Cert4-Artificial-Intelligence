using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
[RequireComponent(typeof(NavMeshAgent))]

public class TowerEnemyTest : MonoBehaviour
{


    public float maxHealth = 100;

    // endpoint of the navmesh for the enemies to go towards
    public Transform target;
    private TowerHP currentEnemy;
    private NavMeshAgent agent;
    public float health = 0;
    public GameObject end;
    public float attackRange = 2f;
    public Slider healthBar;
    public Canvas myCanvas;
    public GameObject resource;
    public ResourceManager resources;
    public int pointValue = 5;

    [Header("UI")]
    public GameObject healthBarPrefab;
    public Transform healthBarParent;
    public Vector3 offset = new Vector3(0f, 2f, 0f);

    private Slider healthSlider;

    void OnDestroy()
    {
        if (healthSlider)
        {
            // Remove from canvas
            Destroy(healthSlider.gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        // Spawn UI
        GameObject clone = Instantiate(healthBarPrefab, healthBarParent);
        healthSlider = clone.GetComponent<Slider>();

        // Set health to whatever the maxhealth is at the start
        health = maxHealth;
        // Getting the navmesh component
        agent = GetComponent<NavMeshAgent>();
        myCanvas = transform.Find("Canvas").GetComponent<Canvas>();
        healthBar = myCanvas.transform.Find("Slider").GetComponent<Slider>();
        //resource = GameObject.FindGameObjectWithTag("Resource");




    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)


        {


            if (Random.value < 0.15f)
            {
                ResourceManager.BPollen += 1;
                Debug.Log("You found a Blue Pollen!");
            }
            if (Random.value < 0.15f)
            {
                ResourceManager.YPollen += 1;
                Debug.Log("You found a Yellow Pollen!");
            }
            if (Random.value < 0.15f)
            {
                ResourceManager.RPollen += 1;
                Debug.Log("You found a Red Pollen!");
            }

            ResourceManager.Score += pointValue;
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        float value = Mathf.Clamp01(health / maxHealth);

        // Position UI and Update Value
        healthSlider.transform.position = Camera.main.WorldToScreenPoint(transform.position + offset);
        healthSlider.value = value;

        healthBar.value = value;
        myCanvas.transform.LookAt(Camera.main.transform);
       // end = GameObject.FindGameObjectWithTag("End");
        // ResourceManager resources = resource.GetComponent<ResourceManager>();

        /*DetectEnemies();

        if (currentEnemy != null)
        {

            target = currentEnemy.transform;
            agent.SetDestination(target.position);




        }*/






        //else
        //{
        //target = end.GetComponent<Transform>();
        agent.SetDestination(target.position);


        // follow destination

        //}
    }



    void DetectEnemies()
    {
        // reset current enemy
        //currentEnemy = null;
        // Perform OverlapSphere
        Collider[] hits = Physics.OverlapSphere(transform.position, attackRange + 1);
        // Loop through everything we hit

        foreach (var hit in hits)
        {
            TowerHP enemy = hit.GetComponent<TowerHP>();
            if (enemy)
            {
                // Set current enemy to that one
                currentEnemy = enemy;
                Debug.Log("I found you");
            }
        }

    }
}


