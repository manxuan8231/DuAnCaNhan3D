using UnityEngine;
using UnityEngine.AI;

public class HunterAI : MonoBehaviour
{
    public int curentHealth = 100;
    public float rangeTarget = 10f;
    public NavMeshAgent agent;
    public Transform player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Bear").transform;
        curentHealth = 100;
    }

    
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < rangeTarget)
        {
            agent.SetDestination(player.position);
        }
    }
    public void TakeDamage(int damage)
    {
        curentHealth -= damage;
        if (curentHealth <= 0)
        {

           Destroy(gameObject);
        }
    }
}
