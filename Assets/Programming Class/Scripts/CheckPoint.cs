using UnityEngine;
using System.Collections;


namespace Checkpoint
{
    //this script can be found in the Component section under the option Intro RPG/Player/Check Point
    [AddComponentMenu("Intro RPG/Player/Check Point")]
    public class CheckPoint : MonoBehaviour

    {
        #region Variables
        [Header("Check Point Elements")]
        //transform for our currentCheck
        public Transform curCheckPoint;
        [Header("Character Health")]
        //character Health script that holds the players health
        public HealthBar health1;

        public void SavePlayer()
        {

        }
        #endregion
        #region Start
        private void Start()
        {
            //Reference to the character health script component attached to our player
            #region Check if we have Key
            //if we have a save key called SpawnPoint
            //then our checkpoint is equal to the game object that is named in out save file or the float x,y,z
            //our transform.position is equal to that of the checkpoint or to the float x,y,z
        }

        #endregion
        #endregion
        #region Update
        private void Update()
        {
            //if our characters health is less than or equal to 0
            if (health1.curHealth <= 0 )
            {

                //our transform.position is equal to that of the checkpoint or float x,y,z
                transform.position = curCheckPoint.position;
                //our characters health is equal to full health
                health1.curHealth = health1.maxHealth; 
                //character is alive
                //characters controller is active	
            }

        }
        #endregion

        #region OnTriggerEnter
        private void OnTriggerEnter(Collider others)//Collider other
        {

            //if our other objects tag when compared is CheckPoint
            if (others.gameObject.CompareTag("CheckPoint"))
            {
                //our checkpoint is equal to the other objects transform
                curCheckPoint = others.transform;

                //save our SpawnPoint as the name of the check point or float x,y,z
                PlayerGame player = this.GetComponent<PlayerGame>();
                player.SaveFunction();
            }
            if (others.gameObject.CompareTag("Danger"))
            {
                health1.curHealth = 0;
                
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Danger"))
            {
             //   health1.curHealth -= 0.1 * Time.deltaTime;

            }
        }
        #endregion
    }
}




