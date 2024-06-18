using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public enum Team
    {
        Red, Blue
    }

    public Transform goal;
    public Team team;

    float speed;
    NavMeshAgent agent;

    public void Move(Transform target)
    {
        //Move agent to target
    }
}
