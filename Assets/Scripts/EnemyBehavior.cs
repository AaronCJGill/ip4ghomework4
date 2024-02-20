using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private Enemy.EnemyType type;
    private Enemy.Behavior behavior = new Enemy.Behavior();
    private NavMeshAgent agent;
    private Animator anim;
    private void Start()
    {
        behavior.init(type);
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = behavior.Speed;
    }

    private void Update()
    {
        agent.SetDestination(Player.instance.transform.position);
        anim.SetFloat("currentSpeed", agent.velocity.magnitude);

        if (Vector3.Distance(transform.position, Player.instance.transform.position) < behavior.Range)
        {
            behavior.attack();
        }
    }

    

}