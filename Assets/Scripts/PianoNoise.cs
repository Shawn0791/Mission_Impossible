using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoNoise : MonoBehaviour
{
    public AudioSource noise;
    public bool isStepping = false;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("???");
        if (other.tag == "Player" && isStepping == false)
        {
            noise.Play();
            isStepping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isStepping = false;
    }
}
