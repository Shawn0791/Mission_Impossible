using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseAnimEvent : MonoBehaviour
{
    public NavMeshAgent agent;

    private float Speed;
    private void Start()
    {
        Speed = agent.speed;
    }

    public void DisableChase()
    {
        agent.speed = 0;
    }
    public void EnableChase()
    {
        agent.speed = Speed;
    }

    public void DisableRotate()
    {
        agent.updateRotation = false;
    }

    public void EnableRotate()
    {
        agent.updateRotation = true;
    }

    public void FootSteps()
    {
        SoundService.instance.Play("MouseFootSteps", 0.7f);
    }

    public void StartChasing()
    {
        agent.speed = 5;
        agent.angularSpeed = 360;


        MouseFSM fsm = transform.parent.GetComponent<MouseFSM>();
        fsm.isBack = false;

        if(fsm.backNum<fsm.hp)
            transform.parent.Find("View").gameObject.SetActive(true);
    }
}
