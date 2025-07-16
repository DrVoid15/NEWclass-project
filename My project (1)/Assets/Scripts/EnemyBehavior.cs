using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Scripting.APIUpdating;

public class EnemyBehavior : MonoBehaviour
{
    public Transform Bean;
    public List<Transform> locations;

    private int LocationIndex = 0;
    private NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
       Bean = GameObject.Find("Bean").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < 0.2f && !agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }
     void IntializePatrolRoute()
    {
        foreach(Transform child in locations)
        {
            locations.Add(child);
        }
     }

    void MoveToNextPatrolLocation()
    {
        if(locations.Count == 0)
        {
            return;
        }
        agent.destination = locations[LocationIndex].position;
        LocationIndex = (LocationIndex + 1) % locations.Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Bean")
        {
            agent.destination = Bean.position;
            Debug.Log("ATTACK!!!!!");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Bean")
        {
            Debug.Log("resume patrol");
        }
    }
}

