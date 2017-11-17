using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
    [SerializeField]
    Transform target;

	// Use this for initialization
	void Start ()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(gameObject.GetComponent<NavMeshAgent>().remainingDistance);

        if (gameObject.GetComponent<NavMeshAgent>().remainingDistance < 0.3f && gameObject.GetComponent<NavMeshAgent>().remainingDistance != 0)
        {
            ScoreManager.lives -= 1;
            Destroy(gameObject);
        }
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="shot")
        {
            Destroy(gameObject);
        }
    }
}
