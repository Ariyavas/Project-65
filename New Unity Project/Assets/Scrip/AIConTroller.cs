using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIConTroller : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    public GameObject target;
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.SetDestination(target.transform.position);
    }
    void Update()
    {
        
    }
}
