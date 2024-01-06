using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandHold : XRBaseInteractable
{
    protected Socket socket = null;
    public void Setup(Socket socket)
    {
        this.socket = socket;
    }

    protected override void Awake()
    {
        base.Awake();
        onSelectEntered.AddListener(Grab);
        onSelectExited.AddListener(Drop);
    }

    private void OnDestroy()
    {
        onSelectEntered.RemoveListener(Grab);
        onSelectExited.RemoveListener(Drop);
    }

    protected virtual void BeginAction(XRBaseInteractor interactor)
    {
        // Empty
    }

    protected virtual void EndAction(XRBaseInteractor interactor)
    {
        // Empty
    }

    protected virtual void Grab(XRBaseInteractor interactor)
    {
        //TryToHideHand(interactor, false);
    }

    protected virtual void Drop(XRBaseInteractor interactor)
    {
        //TryToHideHand(interactor, true);
    }

    private void TryToHideHand(XRBaseInteractor interactor, bool hide)
    {
        //if(interactor is HandController )
    }

    public void BreakHold(XRBaseInteractor interactor)
    {

    }
}