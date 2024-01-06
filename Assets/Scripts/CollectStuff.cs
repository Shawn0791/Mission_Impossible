using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CollectStuff : XRGrabInteractable
{
    public AudioSource hasCollected;
    public GameObject stuff;

    
    /*protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        if(args.interactor.tag == "Hands")
        {
            hasCollected.Play();

            stuff.SetActive(false);
        }

        
    }*/

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        Debug.Log("First Grab Enter");
        base.OnSelectEntered(interactor);
        
        StartCoroutine(Succeed());
    }

    IEnumerator Succeed()
    {
        yield return new WaitForSeconds(1);

        hasCollected.Play();

        stuff.SetActive(false);
    }


}
