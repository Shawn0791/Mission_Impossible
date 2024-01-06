using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class MouseFSM : MonoBehaviour
{
    public NavMeshAgent agent;
    //public ThirdPersonCharacter character;
    public Animator anim;
    public bool canAttack = true;
    public bool isBack;
    public int hp = 3;
    public Transform mouseNest;
    public GameObject view;

    private GameObject player;
    public int backNum;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        backNum = 0;
        view = transform.Find("View").gameObject;
    }

    void Update()
    {
        TestMove();
        Attack();

        anim.SetFloat("Speed", agent.velocity.magnitude);
        //Debug.Log(GetComponent<Rigidbody>().velocity.magnitude);
        //Debug.Log(agent.destination);
    }

    private void TestMove()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }

    private void Attack()
    {
        //Debug.Log(Vector3.Distance(transform.position, player.transform.position));
        if (Vector3.Distance(transform.position, player.transform.position) <= agent.stoppingDistance + 0.5f)
        {
            if (canAttack && !isBack)
            {
                anim.SetTrigger("Attack");
                canAttack = false;
            }
        }
    }

    //private void TestAnimMove()
    //{
    //    if (agent.remainingDistance > agent.stoppingDistance)
    //    {
    //        character.Move(agent.desiredVelocity, false, false);
    //    }
    //    else
    //    {
    //        character.Move(Vector3.zero, false, false);
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            agent.SetDestination(other.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Needle"))
        {
            view.SetActive(false);
            //anim.SetBool("isBack", true);


            if (!isBack)
            {
                SoundService.instance.Play("MouseBarking");
                SoundService.instance.Play("FightBreath");
                anim.SetTrigger("Back");
                backNum++;
            }


            isBack = true;

            agent.speed = 2.5f;
            agent.angularSpeed = 0;
            agent.SetDestination(transform.position - transform.forward * 3);

            if (backNum >= hp)
            {
                view.SetActive(false);
                agent.SetDestination(mouseNest.position);
                Debug.Log("set!");
            }
        }
    }
}
