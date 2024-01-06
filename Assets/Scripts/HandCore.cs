using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCore : MonoBehaviour
{
    public Animator anim;
    private float gripTarget;
    private float gripCurrent;
    private float triggerTarget;
    private float triggerCurrent;

    public float speed;
    private void Update()
    {
        HandAnim();
    }

    internal void SetTrigger(float v)
    {
        triggerTarget = v;
    }

    internal void SetGrip(float v)
    {
        gripTarget = v;
    }

    void HandAnim()
    {
        if(gripCurrent != gripTarget)
        {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * speed);
        }

        anim.SetFloat("Grip", gripCurrent);

        if (triggerCurrent != triggerTarget)
        {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * speed);
        }

        anim.SetFloat("Trigger", triggerCurrent);
    }
}
