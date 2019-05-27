using UnityEngine;
using System.Collections;
//this script can be found in the Component section under the option Intro RPG/Player/Interact

[AddComponentMenu("Intro PRG/RPG/Player/Interact")]

public class Interact : MonoBehaviour
{
    #region Variables

    [Header("Player and Camera connection")]

    //create two gameobject variables one called player and the other mainCam
    public GameObject player;
    public GameObject mainCamera;


    #endregion
    #region Start
    //connect our player to the player variable via tag
    //connect our Camera to the mainCam variable via tag
    #endregion
    #region Update
    private void Update()
    {

        //if our interact key is pressed
        // if (Input.GetButtDown("Interact")) , (Input.GetKeyDown(KeyCode.E)) 
        if (Input.GetButtonDown("Interact"))
        {
            //create a ray which is the line
            Ray interact;

            //this ray is shooting out from the main cameras screen point center of screen

            interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

            //create hit info
            RaycastHit hitInfo;

            //if this physics raycast hits something within 10 units

            if (Physics.Raycast(interact, out hitInfo, 30))
            {
                #region NPC tag

                //and that hits info is tagged NPC

                if (hitInfo.collider.CompareTag("NPC"))
                {
                    Dialogue dlg = hitInfo.transform.GetComponent<Dialogue>();
                    CanvasDialogue dialogue = hitInfo.transform.GetComponent<CanvasDialogue>();
                    if(dlg != null)
                    {
                        dlg.showDlg = true;
                        Movement.canMove = false;
                        Cursor.lockState = CursorLockMode.Confined;
                        Cursor.visible = true; 
                    }
                   /* if(dialogue != null)
                    {
                        dialogue.showDlg = true;
                        Movement.canMove = false;
                        Cursor.lockState = CursorLockMode.Confined;
                        Cursor.visible = true;
                    }
                    */
                    //Debug that we hit a NPC
                    Debug.Log("NPC");

                }
                #endregion

                #region Item


                //and that hits info is tagged Item
                if (hitInfo.collider.CompareTag("Item"))
                {
                    //Debug that we hit an Item
                    Debug.Log("Item");
                    ItemHandler handler = hitInfo.transform.GetComponent<ItemHandler>(); 
                    if(handler != null)
                    {
                        handler.onCollection();
                    }
                }
                #endregion
            }
        }

    }
    #endregion
}






