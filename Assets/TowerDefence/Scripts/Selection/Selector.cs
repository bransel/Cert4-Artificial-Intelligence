using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{

    //[Header("Towers")]
    public GameObject[] towers; // Keep track of towers we spawn


    private GameObject[] holograms;
    private int currentIndex = 0; // Current prefab selected

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
        // Create ray from mouse position on Camera
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit; //raycasthit variable stores a number of information depending on what the raycast hit
        // Perform raycast
        if (Physics.Raycast(mouseRay, out hit)) //physics.raycast(mouseray,out hit) gives you a true or false value
                                                //If true is returned, hitInfo will contain more information about where the collider was hit.
        {

            // Try getting Placeable script
            Placeable p = hit.transform.GetComponent<Placeable>();
            if (p)
            {
                print(p);
            }
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
