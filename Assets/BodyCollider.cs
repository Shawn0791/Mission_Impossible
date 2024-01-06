using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollider : MonoBehaviour
{
    public Transform head;
    CharacterController controller;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void LateUpdate()
    {
        controller.center = new Vector3(head.position.x, 2, head.position.z);
    }
}
