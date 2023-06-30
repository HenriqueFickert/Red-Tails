using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Figurantes : MonoBehaviour {

    private NavMeshAgent agent;

    public Transform[] alvosDePatrulha; 
    private int destPoint;


    void Start () {
        agent = GetComponent<NavMeshAgent>();
	}

	void Update () {
        Patrulhando();
    }

    void Patrulhando()
    {
        if (agent.remainingDistance < agent.stoppingDistance)
        {
            agent.destination = alvosDePatrulha[destPoint].position;
            destPoint = (destPoint + 1) % alvosDePatrulha.Length;
        }
    }
}
