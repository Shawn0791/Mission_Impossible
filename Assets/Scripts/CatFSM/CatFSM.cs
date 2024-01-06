using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFSM : MonoBehaviour
{
    public bool isWarning;
    public Animator boyAnim;

    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Warning();
        }
    }

    private void Warning()
    {
        if (!isWarning)
        {
            isWarning = true;
            anim.SetTrigger("Aware");
            boyAnim.SetTrigger("awake");

            SoundService.instance.Play("Meow");
            SoundService.instance.Play("HeartBeat");
            SoundService.instance.Play("HumanAwake");
        }
    }
}
