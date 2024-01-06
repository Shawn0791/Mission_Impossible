using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketSound : MonoBehaviour
{
    public AudioSource sound;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            sound.Play();
        }
    }
}
