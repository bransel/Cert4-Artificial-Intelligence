using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorTest : MonoBehaviour
{
    public enum PlacementMode
    {
        Nothing = 0,
        Tile = 1,
        Tower = 2
    }

    [Header("Tiles")]
    public GameObject[] tiles; // Keep track of towers we spawn
    public GameObject[] tileHolograms;
    [Header("Towers")]
    public GameObject[] towers;
    public GameObject[] towerHolograms;

    public PlacementMode currentMode = PlacementMode.Nothing;

    [Header("Raycasts")]
    public float rayDistance = 1000f;
    public LayerMask hitlayers;
    public QueryTriggerInteraction triggerInteraction;
    public bool snapToTile = false;

    private int randBlock;
    private int holoRot = 90;
    private int currentTileIndex; // Current prefab selected
    private int currentTowerIndex;

    // Use this for initialization

    public void SetMode(int mode)
    {
        currentMode = (PlacementMode)mode;
    }

    void OnDrawGizmos()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Gizmos.DrawLine(mouseRay.origin, mouseRay.origin + mouseRay.direction * 1000f);
        //Ray CamPos = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Gizmos.DrawLine(CamPos.origin, CamPos.origin + CamPos.direction * 1000f);

    }
    void Start()
    {
        RandomTower();
    }

    // Update is called once per frame
    void Update()
    {
        // Disable all holograms at the start of the frame

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetMode(0);
        }

        DisableAllHolograms();

        // Create ray from mouse position on Camera
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);


        RaycastHit hit; //raycasthit variable stores a number of information depending on what the raycast hit

        // Perform raycast
        if (currentMode == PlacementMode.Tile)
        {
            hitlayers = hitlayers = LayerMask.GetMask("Terrain");
        }

        if (currentMode == PlacementMode.Tower)
        {
            hitlayers = LayerMask.GetMask("TowerPlace");
        }

        if (Physics.Raycast(mouseRay, out hit, rayDistance, hitlayers, triggerInteraction)) //physics.raycast(mouseray,out hit) gives you a true or false value
                                                                                            //If true is returned, hitInfo will contain more information about where the collider was hit.
                                                                                            // if(Physics.SphereCast(CamPos, SR, out hit, rayDistance, hitlayers, triggerInteraction))
        {
            PlaceableTest placeable = hit.collider.GetComponent<PlaceableTest>();
            Vector3 placeablePoint = hit.point;

            if (snapToTile && placeable)
            {
                placeablePoint = placeable.GetPivotPoint();
            }


              GameObject prefab = null;
             GameObject hologram = null;
            

            switch (currentMode)
            {
                case PlacementMode.Nothing:
                    
                    break;
                case PlacementMode.Tile:
                    prefab = tiles[currentTileIndex];
                    hologram = tileHolograms[currentTileIndex];
                    //hitlayers = LayerMask.GetMask("Terrain");
                    break;
                case PlacementMode.Tower:
                    prefab = towers[currentTowerIndex];
                    hologram = towerHolograms[currentTowerIndex];
                    //hitlayers = LayerMask.GetMask("TowerPlace");
                    break;
                default: 

                      
                
                    break;
            }

            if (hologram)
            {
                hologram.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hologram.transform.Rotate(0, holoRot, 0);
                }
                hologram.transform.position = placeablePoint;

                if (Input.GetMouseButtonDown(0))
                {
                    // Actual tower is the actual tower and not the tetris blocks
                    Transform cylinder = hit.collider.GetComponent<Transform>();
                    GameObject clone = Instantiate(prefab);
                    clone.transform.position = placeablePoint;
                    clone.transform.rotation = hologram.transform.rotation;
                    bool ok = true; 
                    clone.transform.SetParent(cylinder, ok);
                  
                    RandomTower();

                    if (placeable)
                    {
                        placeable.isAvailable = false;
                    }
                }
            }


            /*
            if (snapToTile)
            {
                // Try getting Placeable script
                PlaceableTest p = hit.transform.GetComponent<PlaceableTest>();
                // If it is a placeable and it's available (no tower)
                if (p && p.isAvailable)
                {
                    //Get position of placeable
                    Vector3 placeablePoint = p.GetPivotPoint();
                    if (placeTower)
                    {
                        GameObject holoT = towerHolograms[currentTowerIndex];
                        holoT.SetActive(true);

                        holoT.transform.position = placeablePoint;
                        if (Input.GetMouseButtonDown(0))
                        {
                            GameObject tower = towers[currentTowerIndex];
                            // Actual tower is the actual tower and not the tetris blocks
                            GameObject Actualtower = Instantiate(tower);
                            Actualtower.transform.position = p.GetPivotPoint();
                            // The tile is no longer available
                            p.isAvailable = false;
                        }

                    }
                    else
                    {
                        //Debug.Log(hitlayers);
                        // Get hologram of current tower
                        GameObject hologram = tileHolograms[currentTileIndex];
                        hologram.SetActive(true);
                        // Set position of hologram
                        // hologram.transform.position = hit.point;
                        hologram.transform.position = placeablePoint;

                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            hologram.transform.Rotate(0, holoRot, 0);
                        }
                        
                        // If Left mouse is down
                        if (Input.GetMouseButtonDown(0))
                        {
                            // Get the prefab
                            GameObject towerPrefab = tiles[currentTileIndex];
                            // Spawn the tower
                            GameObject tower = Instantiate(towerPrefab);
                            // tower.transform.position = hit.point;
                            tower.transform.localRotation = hologram.transform.localRotation;
                            // Position to placeable
                            tower.transform.position = p.GetPivotPoint();
                            // The tile is no longer available
                            p.isAvailable = false;
                            //Reset Tower Random
                            RandomTower();
                        }
                    }
                }
            }
            */
        }
    }
    /// <summary>
    /// Disables the GameObjects of all referenced Holograms
    /// </summary>
    void DisableAllHolograms()
    {
        foreach (var holo in tileHolograms)
        {
            holo.SetActive(false);
        }
        foreach (var holo in towerHolograms)
        {
            holo.SetActive(false);
        }
    }
    /// <summary>
    /// Changes CurrentIndex to selected index with filters
    /// </summary>
    /// <param name="index"></param>
    public void RandomTower()
    {
        /*// Is index in range of prefabs
        if (index >=0 && index < towers.Length)
        {
            // Set current index
            currentIndex = index;
        }*/
        int RandBlock = Random.Range(0, tileHolograms.Length);
        currentTileIndex = RandBlock;
    }

}
