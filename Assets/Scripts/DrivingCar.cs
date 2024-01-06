using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.AI;

public class DrivingCar : XRBaseInteractable
{
    public GameObject car;
    public bool isDriving = false;
    public float speed = 10f;

    public NavMeshAgent agent;
    public GameObject target;
    public bool isGrounded;

    public CarEnter carEnter;
    public AudioSource sound;

    //public WalkInPlaceLocomotion walkInPlaceLocomotion;

    void Start()
    {
        XRBaseInteractor interactor = selectingInteractor;

        IXRSelectInteractor newInteractor = firstInteractorSelecting;

        List<IXRSelectInteractor> moreInteractors = interactorsSelecting;
    }

    void FixedUpdate()
    {
        //isGrounded = (Physics.Raycast((new Vector3(car.transform.position.x, car.transform.position.y, car.transform.position.z)), Vector3.down, 0.1f));

        //Debug.DrawRay((new Vector3(car.transform.position.x, car.transform.position.y, car.transform.position.z)), Vector3.down, Color.red, 0.1f);
        //Debug.Log(isGrounded);

        /*if (!isGrounded)
        {
            car.transform.position = new Vector3(car.transform.position.x, car.transform.position.y-0.2f, car.transform.position.z);
        }*/
        if (isDriving)
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            Debug.Log("Drving!");
            if (!sound.isPlaying)
            {
                sound.Play();
            }
                
            agent.isStopped = false;
            car.GetComponent<Rigidbody>().isKinematic = false;
            //walkInPlaceLocomotion.enabled = false;

            //car.GetComponent<Rigidbody>().AddForce(car.transform.forward * speed);
            agent.SetDestination(target.transform.position);
        }
        else
        {
            sound.Stop();
            agent.isStopped = true;
            car.GetComponent<Rigidbody>().isKinematic = true;
            
        }

        float dist = Vector3.Distance(car.transform.position, target.transform.position);

        if (dist < 1)
        {
            isDriving = false;
            agent.isStopped = true;
            car.GetComponent<Rigidbody>().isKinematic = true;
            carEnter.ExitCar();
        }

    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        if (HasMultiInteractors())
        {
            Debug.Log("HasMultiInteractors");
            //Compute the rotation
            //selectingInteractor.attachTransform.rotation = Quaternion.LookRotation(moreInteractors[0].attachTransform.position - selectingInteractor.attachTransform.position);
            isDriving = true;
        }
        
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        if (HasNoInteractors())
        {
            Debug.Log("HasNoInteractors");
            isDriving = false;
        }
            
    }

    private bool HasNoInteractors()
    {
        return interactorsSelecting.Count == 0;
    }
    private bool HasMultiInteractors()
    {
        return interactorsSelecting.Count > 1;
    }

    void Update()
    {
        
    }
}
