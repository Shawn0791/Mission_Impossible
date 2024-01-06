using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEnter : MonoBehaviour
{

    public Transform driverSeat;
    public GameObject player;
    public Transform exitPosi;

    public GameObject locomotion;
    public CharacterController characterController;
    public CharacterDriver characterDriver;

    public WalkInPlaceLocomotion walkInPlaceLocomotion;
    //public Jumping jumping;

    bool inCar = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            characterController.enabled = false;
            //jumping.enabled = false;
            //locomotion.SetActive(false);
            //characterDriver.enabled = false;
            walkInPlaceLocomotion.enabled = false;

            player.transform.position = driverSeat.position;
            player.transform.rotation = driverSeat.rotation;
            player.transform.parent = driverSeat;

            inCar = true;

            Debug.Log("YYYY");
        }
        
    }
    public void ExitCar()
    {
        if (inCar)
        {
            player.transform.parent = null;
            player.transform.position = exitPosi.position;
            player.transform.rotation = exitPosi.rotation;


            characterController.enabled = true;
            //characterDriver.enabled = true;
            walkInPlaceLocomotion.enabled = true;
            //jumping.enabled = true;
            //locomotion.SetActive(true);

            Debug.Log("Exit the car");

            inCar = false;
        }
        
    }
}
