using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catIdleBehaviour : MonoBehaviour
{
    public Animator animator;

    private void Update()
    {
        int a = Random.Range(0, 10);
        animator.SetInteger("IdleRandom", a);
    }
}
