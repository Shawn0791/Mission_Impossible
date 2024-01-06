using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : MonoBehaviour
{
    public GameObject Handle;
    public GameObject Honey;
    public float speed;

    private float progress = 0;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Honey"))
        {
            SuckingHoney();
        }
    }

    private void SuckingHoney()
    {
        //handle:0.05~-0.17！！y
        //honey:0~1！！x
        //y=-0.22x+0.05
        if (progress < 1)
            progress += speed * Time.deltaTime;

        float y = -0.22f * progress + 0.05f;
        Handle.transform.localPosition = new Vector3(Handle.transform.localPosition.x, y, Handle.transform.localPosition.z);

        Honey.transform.localScale = new Vector3(1, progress, 1);
    }
}
