using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;
using Unity.XR.CoreUtils;
using UnityEngine.XR;

public class WalkInPlaceLocomotion : MonoBehaviour
{
    [SerializeField] CharacterController characterController;

    [SerializeField] GameObject leftHand, rightHand;

    Vector3 previousPosLeft, previousPosRight, direction;

    //Vector3 gravity = new Vector3(0, -9.8f, 0);
    public float gravity = 20f;

    public Vector3 moveVelocity;

    public float walkSpeed = 2;
    public float runSpeed = 4;
    float speed = 0;
    // Start is called before the first frame update


    [SerializeField]
    private XRNode controllerNode = XRNode.RightHand;

    private InputDevice controller;

    public bool isGrounded;

    private List<InputDevice> devices = new List<InputDevice>();

    public InputDeviceCharacteristics controllerCharacteristics;

    public float lVelocityValue;
    public float rVelocityValue;

    public float jumpHeight = 5f;

    public Vector3 jumpVelocity;

    public DrivingCar drivingCar;

    [Header("Sounds")]
    public AudioSource walkingSteps;
    public AudioSource runningSteps;
    public AudioSource jumpAudio;

    void Start()
    {
        SetPreviousPos();
        GetDevice();

        walkingSteps.Pause();
    }

    private void GetDevice()
    {
        InputDevices.GetDevicesAtXRNode(controllerNode, devices);
        controller = devices.FirstOrDefault();
    }

    // Update is called once per frame
    void Update()
    {
        GetDevice();
        //Calculate the velocity of the player hand movement 
        Vector3 leftHandVelocity = leftHand.transform.position - previousPosLeft;
        Vector3 rightHandVelocity = rightHand.transform.position - previousPosRight;
        lVelocityValue = leftHandVelocity.magnitude;
        rVelocityValue = rightHandVelocity.magnitude;
        //totalVelocity = +leftHandVelocity.magnitude * 0.8f + rightHandVelocity.magnitude * 0.8f;

        if (lVelocityValue >= 0.02f && rVelocityValue >= 0.02f)//If true Player has swing their hand
        {
            //getting the direction that the player is facing
            direction = Camera.main.transform.forward;
            speed = walkSpeed;
            if (lVelocityValue >= 0.05f && rVelocityValue >= 0.05f) { 
                speed = runSpeed;
                if (!runningSteps.isPlaying && !drivingCar.isDriving)
                {
                    runningSteps.Play();
                }
            }
            else
            {
                if (!walkingSteps.isPlaying && !drivingCar.isDriving)
                {
                    walkingSteps.Play();
                }
            }
            
            //move the player using character controller
            characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up));

            
            

        }

        if(!isGrounded && (Physics.Raycast((new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z)), Vector3.down, 0.6f)))
        {
            jumpAudio.Play();
        }

        isGrounded = (Physics.Raycast((new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z)), Vector3.down, 0.6f));
        //Debug.Log(isGrounded);

        Debug.DrawRay((new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z)), Vector3.down, Color.red, 0.5f);

        //if (!characterController.isGrounded)
        //yield return null; //
        // return;

        bool buttonValue;

        controller.TryGetFeatureValue(CommonUsages.primaryButton, out buttonValue);
        //Debug.Log(buttonValue);

        if (isGrounded && jumpVelocity.y < 0)
        {
            jumpVelocity.y = -2f;
        }
        //Debug.Log(buttonValue);
        if (buttonValue && isGrounded)
        {
            jumpVelocity.y = Mathf.Sqrt(jumpHeight * 2 * gravity);
            //Debug.Log("Jump!");
        }
        jumpVelocity.y -= gravity * Time.deltaTime;
        characterController.Move(jumpVelocity * Time.deltaTime);

        //Debug.Log(jumpVelocity);

        /*//Applying gravity
        moveVelocity.y -= gravity * Time.deltaTime;
        characterController.Move(moveVelocity * Time.deltaTime);*/
        SetPreviousPos();

        //UpdateJump(controller);
    }

    

    

    private void UpdateJump(InputDevice controller)
    {
        isGrounded = (Physics.Raycast((new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z)), Vector3.down, 1.5f));

       //Debug.DrawRay((new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z)), Vector3.down, Color.red, 1.5f);
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

    void SetPreviousPos()
    {
        previousPosLeft = leftHand.transform.position;
        previousPosRight = rightHand.transform.position;
    }
}
