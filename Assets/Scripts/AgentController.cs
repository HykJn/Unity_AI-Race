using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public Transform goal;
    public Team team;

    bool isGoal;
    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        isGoal = false;
    }

    private void Update()
    {
        Goal();
    }

    public void Move()
    {
        agent.speed = Random.Range(4f, 6f);
        agent.SetDestination(goal.position);
    }

    public void Goal()
    {
        if (Vector3.Distance(this.gameObject.transform.position, goal.transform.position) <= 3f && !isGoal)
        {
            SoundManager.Instance.PlaySound("Goal");
            if (team == Team.Red) GameManager.Instance.resultRed++;
            else GameManager.Instance.resultBlue++;
            UIManager.Instance.UpdateScore();
            isGoal = true;
        }
    }
}