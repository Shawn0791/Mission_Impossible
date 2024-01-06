using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Socket : XRGrabInteractable
{
    private GripHold gripHold = null;

    private XRBaseInteractor gripHand = null;

    private readonly Vector3 gripRotation = new Vector3(45, 0, 0);
    protected override void Awake()
    {
        base.Awake();
        SetupHolds();

        onSelectEntered.AddListener(SetInitialRotation);
    }

    private void SetupHolds()
    {
        gripHold = GetComponentInChildren<GripHold>();
        gripHold.Setup(this);
    }

    private void SetupExtras()
    {

    }

    private void OnDestroy()
    {
        onSelectEntered.RemoveListener(SetInitialRotation);
    }

    private void SetInitialRotation(XRBaseInteractor interactor)
    {
        Quaternion newRotation = Quaternion.Euler(gripRotation);
        interactor.attachTransform.localRotation = newRotation;
    }

    public void SetGripHand(XRBaseInteractor interactor)
    {
        gripHand = interactor;
        OnSelectEntered(gripHand);
    }

    public void ClearGripHand(XRBaseInteractor interactor)
    {
        gripHand = null;
        OnSelectExited(gripHand);
    }

    public void SetGuardHand(XRBaseInteractor interactor)
    {

    }

    public void ClearGuardHand(XRBaseInteractor interactor)
    {

    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);
    }

    private void SetGripRotation()
    {

    }

    private void CheckDistance(XRBaseInteractor interactor, HandHold handHold)
    {

    }

    public void PullTrigger()
    {

    }

    public void ReleaseTrigger()
    {

    }

    public void ApplyRecoil()
    {

    }
}
