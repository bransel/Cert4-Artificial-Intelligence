using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class TowerCharacter : MonoBehaviour {
    public Transform target;
    public float rayDistance = 1000f;
    public LayerMask hitlayers;
    private NavMeshAgent agent;
    private Transform walkTo;
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
       
    }
	
	// Update is called once per frame
	void Update () {
       

        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButton(1))
        {
            if(Physics.Raycast(mouseRay, out hit, rayDistance, hitlayers))
            {
                
                agent.SetDestination(hit.point);
            }
        }
        
    }
}
