using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandController : MonoBehaviour
{
    public ActionBasedController _controller;

    public HandCore _handcore;

    void Update()
    {
        _handcore.SetGrip(_controller.selectAction.action.ReadValue<float>());
        _handcore.SetTrigger(_controller.activateAction.action.ReadValue<float>());
    }
}
