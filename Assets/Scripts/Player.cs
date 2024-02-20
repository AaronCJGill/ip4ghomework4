using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public float health = 100;
    Rigidbody rb;
    public static Player instance;
    NavMeshAgent agent;
    Animator anim; 
    private void Awake()
    {
        if (instance != this && instance != null)
        {
            Destroy(gameObject);
        }
        else if (instance == null)
        {
            instance = this;
        }
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.speed = 10;
    }


    void Update()
    {
        //move player
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                //Debug.Log(hit.transform.name);
                agent.SetDestination(hit.point);
            }
        }

        if (health < 0)
        {
            GameManager.instance.playerDied();
        }

        //update animator
        anim.SetFloat("currentSpeed", agent.velocity.magnitude);
        //Debug.Log(agent.velocity.magnitude);

    }

}
