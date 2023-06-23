using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;

    public Transform player;

    public LayerMask playerLayer, groundLayer;

    // Patrolling Area
    public Vector3 walkPoint;
    bool walkPointSet;
    [SerializeField] float walkPointRange;

    // Check for range
    [SerializeField] float sightRange;
    public bool playerInRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);

        if (!playerInRange)
        {
            Patrolling();
        }
        
        if (playerInRange)
        {
            ChasePlayer();
        }
    }

    void Patrolling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            navMeshAgent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        // Walkpoint has been reached
        if (distanceToWalkPoint.magnitude < 1)
        {
            walkPointSet = false;
        }
    }

    void SearchWalkPoint() //  Makes a random search point for the enemy to walk to
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ); // creates new patrol point

        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundLayer)) // If below the walkpoint is a ground layer,
        {
            walkPointSet = true; // the walkpoint can be set
        }
    }

    void ChasePlayer()
    {
        navMeshAgent.SetDestination(player.position);
    }
}
