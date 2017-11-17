using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
    [SerializeField]
    Transform target;
    Gamemaster master;

	// Use this for initialization
	void Start ()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
        master = GameObject.FindGameObjectWithTag("Gamemaster").GetComponent<Gamemaster>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(gameObject.GetComponent<NavMeshAgent>().remainingDistance);

        if (gameObject.GetComponent<NavMeshAgent>().remainingDistance < 0.3f && gameObject.GetComponent<NavMeshAgent>().remainingDistance != 0)
        {
            master.Takedamage();
            Destroy(gameObject);
        }
	}

}
