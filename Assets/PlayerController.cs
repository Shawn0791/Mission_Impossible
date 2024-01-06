using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OVRPlayerController))]

public class PlayerController : MonoBehaviour
{
    private OVRPlayerController controller;

    public float moveSpeed = 3f;

    public bool allowDoubleXSpeed = false;

    private void Start()
    {
        controller = GetComponent<OVRPlayerController>();
        controller.SetMoveScaleMultiplier(moveSpeed);
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            controller.Jump();
        }

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && allowDoubleXSpeed)
        {
            controller.SetMoveScaleMultiplier(moveSpeed * 2f);
        }
        else
        {
            controller.SetMoveScaleMultiplier(moveSpeed);
        }
    }
}


/*
public class PlayerController : MonoBehaviour
{
    public InputActionReference jumpActionReference;
    public float jumpForce = 500f;

    private XROrigin xrRig;
    private CapsuleCollider _collider;
    private Rigidbody rb;

    private bool isGrounded => Physics.Raycast(
        new Vector2(transform.position.x, transform.position.y + 2f),
        Vector3.down, 2f);

    void Start()
    {
        xrRig = GetComponent<XROrigin>();
        _collider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        jumpActionReference.action.performed += OnJump;
    }

    // Update is called once per frame
    void Update()
    {
        var center = xrRig.CameraInOriginSpacePos;
        _collider.center = new Vector3(center.x, _collider.center.y, center.z);
        _collider.height = xrRig.CameraInOriginSpaceHeight;
    }

    private void OnJump(InputAction.CallbackContext obj)
    {
        if (!isGrounded)
            return;
        rb.AddForce(Vector3.up * jumpForce);
    }
}*/
