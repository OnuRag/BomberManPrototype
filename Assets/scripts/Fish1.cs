using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class Fish1 : MonoBehaviour
{
    //public Transform player;
    public GameObject player;
    
    public NavMeshAgent agent;

    public enum State
    {
        patrol,
        chase
    }
    public State state;
    private bool alive;
    


    public GameObject[] waypoints;
    private int waypointIndex;
    float patrolspeed = 5;

    private float chaseSpeed = 6f;
  

    Vector3 startPosition;
    Vector3 currentPosition;
    Vector3 lastPosition;

    void Start()
    {
        //NavMeshAgent agent = GetComponent<NavMeshAgent>();
        //agent.destination = player.transform.position;
        //agent.destination = player.position;
        //agent.updatePosition = true;
        //agent.updateRotation = true;
        state = Fish1.State.patrol;
        alive = true;
        //start fsm
        //StartCoroutine(FSM());
        //Debug.Log("Start");
        
        //Patrol();



    }
    private void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = player.transform.position;
    }

    IEnumerator FSM()
    {

            while(alive)
        {
            switch (state)
            {
                case State.patrol:
                    Patrol();
                    Debug.Log("FSM");
                    break;
                case State.chase:
                    Chase();
                    break;
            }
        }
        Debug.Log("EM");

        yield return null;
    }
    void Patrol()
    {
       
        agent.speed = patrolspeed;
        if(Vector3.Distance(this.transform.position,waypoints[waypointIndex].transform.position)>2)
        {
            agent.SetDestination(waypoints[waypointIndex].transform.position);
            Debug.Log("this from patrol func ");
        }
        else if (Vector3.Distance(this.transform.position, waypoints[waypointIndex].transform.position) < 2)
        {
            waypointIndex += 1;
            if(waypoints.Length < waypointIndex)
            {
                waypointIndex = 0;
            }
        }
    }
    
    void Chase()
    {
        agent.speed = chaseSpeed;
        agent.SetDestination(player.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
      if(other.tag=="Player")
        {
            state = Fish1.State.chase;
        }
    }
}