using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;
using Unity.XR.CoreUtils;
using UnityEngine.XR;

//[RequireComponent(typeof(Rigidbody))]
//[RequireComponent(typeof(CapsuleCollider))]
public class Jumping : MonoBehaviour
{
    [SerializeField]
    private XRNode controllerNode = XRNode.RightHand;

    private InputDevice controller;

    public bool isGrounded;

    private List<InputDevice> devices = new List<InputDevice>();

    public enum CapsuleDirection
    {
        XAxis,
        YAxis,
        ZAxis
    }

    void OnEnable()
    {
        /*rigidBodyComponent = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        rigidBodyComponent.constraints = RigidbodyConstraints.FreezeRotation;
        capsuleCollider.direction = (int)capsuleDirection;
        capsuleCollider.radius = capsuleRadius;
        capsuleCollider.center = capsuleCenter;
        capsuleCollider.height = capsuleHeight;*/
    }

    public InputDeviceCharacteristics controllerCharacteristics;

    void Start()
    {
        GetDevice();
        
        //Debug.Log(controller);
    }

    private void GetDevice()
    {
        InputDevices.GetDevicesAtXRNode(controllerNode, devices);
        controller = devices.FirstOrDefault();
    }
    bool test = false;
    void Update()
    {
        /*List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (controller == null)
        {
            GetDevice();
            Debug.Log("???????");
        }*/
        GetDevice();
        //UpdateMovement();

        UpdateJump(controller);

        

        controller.TryGetFeatureValue(CommonUsages.primaryButton, out test);
        //Debug.Log(test);
    }

    /*private void UpdateMovement()
    {
        Vector2 primary2dValue;

        InputFeatureUsage<Vector2> primary2DVector = CommonUsages.primary2DAxis;

        if (controller.TryGetFeatureValue(primary2DVector, out primary2dValue) && primary2dValue != Vector2.zero)
        {
            //Debug.Log("primary2DAxisClick is pressed " + primary2dValue);

            var xAxis = primary2dValue.x * speed * Time.deltaTime;
            var zAxis = primary2dValue.y * speed * Time.deltaTime;

            Vector3 right = transform.TransformDirection(Vector3.right);
            Vector3 forward = transform.TransformDirection(Vector3.forward);

            transform.position += right * xAxis;
            transform.position += forward * zAxis;
        }
    }*/

    /*private void UpdateJump(InputDevice controller)
    {
        isGrounded = (Physics.Raycast((new Vector2(transform.position.x, transform.position.y + 2.0f)), Vector3.down, 5.0f));

        Debug.DrawRay((new Vector3(transform.position.x, transform.position.y, transform.position.z)), Vector3.down, Color.red, 1.0f);

        if (!isGrounded)
            //yield return null; //
            return;

        bool buttonValue;

        controller.TryGetFeatureValue(CommonUsages.primaryButton, out buttonValue);

        if (buttonValue)
        {
            //Debug.Log("@@@@@@@@@");
            if (!buttonPressed)
            {
                Debug.Log("primaryButton is pressed " + buttonValue);
                buttonPressed = true;
                rigidBodyComponent.AddForce(Vector3.up * jumpForce);
            }
        }
        else if (buttonPressed)
        {
            Debug.Log("primaryButton is released " + buttonValue);
            buttonPressed = false;
        }

        //yield return null;
    }*/

    public CharacterController characterController;

    public float gravity = 9.8f;

    public float jumpHeight = 5f;

    public Vector3 jumpVelocity;

    private void UpdateJump(InputDevice controller)
    {
        isGrounded = (Physics.Raycast((new Vector3(transform.position.x, transform.position.y+1f, transform.position.z)), Vector3.down, 1.5f));

        Debug.DrawRay((new Vector3(transform.position.x, transform.position.y+1f, transform.position.z)), Vector3.down, Color.red, 1.5f);
        //Debug.Log(isGrounded);

        //if (!characterController.isGrounded)
            //yield return null; //
           // return;

        bool buttonValue;

        controller.TryGetFeatureValue(CommonUsages.primaryButton, out buttonValue);
        if (!isGrounded && jumpVelocity.y < 0)
        {
            jumpVelocity.y = -2f;
        }
        //Debug.Log(buttonValue);
        if (buttonValue && isGrounded)
        {
            jumpVelocity.y = Mathf.Sqrt(jumpHeight * 2 * gravity);
        }
        jumpVelocity.y -= gravity * Time.deltaTime;
        characterController.Move(jumpVelocity * Time.deltaTime);
        
    }
}