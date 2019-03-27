using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{

    //[Header("Towers")]
    public GameObject[] towers; // Keep track of towers we spawn
    
    public GameObject[] holograms;
    [Header("Raycasts")]
    public float rayDistance = 1000f;
    public LayerMask hitlayers;
    public QueryTriggerInteraction triggerInteraction;

    private int currentIndex; // Current prefab selected

    // Use this for initialization

    void OnDrawGizmos()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Gizmos.DrawLine(mouseRay.origin, mouseRay.origin + mouseRay.direction * 1000f);   
    }
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        // Disable all holograms at the start of the frame

        DisableAllHolograms(); 

        // Create ray from mouse position on Camera
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit; //raycasthit variable stores a number of information depending on what the raycast hit
        // Perform raycast
        if (Physics.Raycast(mouseRay, out hit, rayDistance, hitlayers, triggerInteraction)) //physics.raycast(mouseray,out hit) gives you a true or false value
                                                //If true is returned, hitInfo will contain more information about where the collider was hit.
        {

            // Try getting Placeable script
            Placeable p = hit.transform.GetComponent<Placeable>();
            // If it is a placeable and it's available (no tower)
            if (p && p.isAvailable)
            {
                //Get position of placeable
                Vector3 placeablePoint = p.transform.position;

                // Get hologram of current tower
                GameObject hologram = holograms[currentIndex];
                hologram.SetActive(true);
                // Set position of hologram
                hologram.transform.position = p.GetPivotPoint();

                // If Left mouse is down
                if (Input.GetMouseButtonDown(0))
                {
                    // Get the prefab
                    GameObject towerPrefab = towers[currentIndex];

                    // Spawn the tower
                    GameObject tower = Instantiate(towerPrefab);

                    // Position to placeable
                    tower.transform.position = p.GetPivotPoint();

                    // The tile is no longer available
                    p.isAvailable = false; 
                }
            }
        }
    }
    /// <summary>
    /// Disables the GameObjects of all referenced Holograms
    /// </summary>
    void DisableAllHolograms()
    {
        foreach (var holo in holograms)
        {
            holo.SetActive(false);
        }
    }
    /// <summary>
    /// Changes CurrentIndex to selected index with filters
    /// </summary>
    /// <param name="index"></param>
    public void SelectTower (int index)
    {
        // Is index in range of prefabs
        if (index >=0 && index < towers.Length)
        {
            // Set current index
            currentIndex = index;
        }
    }
}
