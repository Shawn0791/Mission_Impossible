using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float chaseSpeed;
    public float backSpeed;
    public float backDis;

    [SerializeField] private bool isChasing;
    [SerializeField] private bool isRecoiling;
    private Rigidbody rb;
    private Animator anim;
    private GameObject player;
    private Vector3 targetPos;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isChasing)
            Chasing();
        else if (isRecoiling)
            Recoiling();
    }

    private void Chasing()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            player.transform.position, chaseSpeed * Time.deltaTime);

        //face to the player when chasing
        transform.forward = (player.transform.position - transform.position).normalized;
    }

    private void Recoiling()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            targetPos, backSpeed * Time.deltaTime);

        transform.forward = (transform.position - targetPos).normalized;

        if (Vector3.Distance(transform.position, targetPos) < 0.5f)
        {
            isRecoiling = false;
            isChasing = true;
            Debug.Log("back finished");
        }
    }

    public void StepBack(Vector3 swordPos)
    {
        Vector3 pos = new Vector3(swordPos.x, transform.position.y, swordPos.z);
        Vector3 dir = (transform.position - pos).normalized;
        targetPos = transform.position + dir * backDis;
        isChasing = false;
        isRecoiling = true;
    }



}
