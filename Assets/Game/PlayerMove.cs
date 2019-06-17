using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    public float moveDist = 9;
    public GameObject radar;
    public GameObject spot;
    private bool myTurn = true;
    private Vector3 click;
 public GameObject spoton;
    NavMeshAgent agent;
    public LayerMask mask;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        radar.transform.localScale = new Vector3(moveDist, radar.transform.localScale.y, moveDist);
    }

    // Update is called once per frame
    void Update()
    {
        ClickMove();
    }

    public void ClickMove()
    {
        if (myTurn)
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            radar.SetActive(true);
            if (Physics.Raycast(mouseRay, out hit,10000,mask))
           {


                spot.SetActive(true);
                spot.transform.position = hit.point;

                {
                    if (Input.GetMouseButtonDown(1))
                    {


                        click = hit.point;
                        spoton.SetActive(true);
                        spoton.transform.position = hit.point;

                        agent.SetDestination(click);
                        if (Vector3.Distance(transform.position,spoton.transform.position)<= 1)
                        {
                            radar.SetActive(false);
                        }


                    }
                }
            }
            else
            {
                spot.SetActive(false);
            }
        }
    }
    
}
