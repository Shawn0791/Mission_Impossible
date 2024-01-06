using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBackBehaviour : StateMachineBehaviour
{
    private float timer = 2;
    private GameObject player;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.GetComponent<MouseAnimEvent>().DisableChase();
        //animator.GetComponent<MouseAnimEvent>().DisableRotate();
        //animator.transform.parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //animator.transform.parent.GetChild(1).gameObject.SetActive(false);//view
        //player = GameObject.FindGameObjectWithTag("Player");
        //timer = 2;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //timer -= Time.deltaTime;
        //Vector3 vector = (animator.transform.parent.position - player.transform.position).normalized;
        //animator.transform.parent.GetComponent<Rigidbody>().velocity = vector * 2f;

        //if (timer <= 0)
        //    animator.SetBool("isBack", false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.GetComponent<MouseAnimEvent>().EnableChase();
        //animator.GetComponent<MouseAnimEvent>().EnableRotate();
        //animator.transform.parent.GetChild(1).gameObject.SetActive(true);//view
        //animator.transform.parent.GetComponent<Rigidbody>().velocity = Vector3.zero;

        animator.GetComponent<MouseAnimEvent>().StartChasing();
        animator.SetBool("isBack", false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
