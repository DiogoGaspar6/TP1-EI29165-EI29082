using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MovimentoNPC : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform point;
    public Animator animator;
    private bool isStopped = false;
    private float distance = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); 
        agent.SetDestination(point.position);
    }

    // Update is called once per frame
    void Update()
    {     
            if (agent.remainingDistance <= distance && !isStopped){
                isStopped = true;
                agent.ResetPath();
                animator.SetBool("isStopped", isStopped);
            }
            
    }
}


