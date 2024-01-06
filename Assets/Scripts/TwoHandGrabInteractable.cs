using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TwoHandGrabInteractable : XRGrabInteractable
{
    public List<XRSimpleInteractable> secondHandGrabPoints = new List<XRSimpleInteractable>();
    private XRBaseInteractor secondInteractor;

    void Start()
    {
        foreach(var item in secondHandGrabPoints)
        {
            item.onSelectEntered.AddListener(OnSecondHandGrab);
            item.onSelectExited.AddListener(OnSecondHandRelease);
        }
    }

    void Update()
    {
        
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase) // Override all the ovject move
    {
        if(secondInteractor && selectingInteractor)
        {
            //Compute the rotation
            selectingInteractor.attachTransform.rotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position);
        }
        base.ProcessInteractable(updatePhase);
    }

    public void OnSecondHandGrab(XRBaseInteractor interactor)
    {
        Debug.Log("OnSecondHandGrab");
        secondInteractor = interactor;
    }

    public void OnSecondHandRelease(XRBaseInteractor interactor)
    {
        Debug.Log("OnSecondHandRelease");
        secondInteractor = null;
    }

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        Debug.Log("First Grab Enter");
        base.OnSelectEntered(interactor);
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        Debug.Log("First Grab Exit"); 
        base.OnSelectExited(interactor);
        secondInteractor = null; // Force to release second hand when the 1st hand is released
    }

    public override bool IsSelectableBy(XRBaseInteractor interactor) //Can't grab it when it is already grabbed.
    {
        
        if(secondInteractor == null)
        {
            return false;
        }
        else
        {
            //bool isTwoHandGrabbed = selectingInteractor && !interactor.Equals(selectingInteractor);
            return base.IsSelectableBy(interactor);// && isTwoHandGrabbed;
        }
        
    }
}
