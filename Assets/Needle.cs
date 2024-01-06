using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour
{
    public Transform swordPoint;
    public BoxCollider swordArea;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //pick up the needle
            swordArea.enabled = true;
            transform.SetParent(other.transform);//the parent need to be the hand
        }
        else if (other.CompareTag("Mouse"))
        {
            //scare away the mouse
            other.GetComponent<MouseMovement>().StepBack(swordPoint.position);
        }
    }
}

