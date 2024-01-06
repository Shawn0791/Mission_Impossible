using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarKinematicControl : MonoBehaviour
{
    public Rigidbody carRigidbody;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            carRigidbody.isKinematic = true;
    }
    private void OnTriggerExit(Collider other)
    {
        //if (other.tag == "Player")
            //carRigidbody.isKinematic = false;
    }
}
