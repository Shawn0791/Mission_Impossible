using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyPot : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //SoundService.instance.Play("PotCollision", 0.5f);
    }
}
