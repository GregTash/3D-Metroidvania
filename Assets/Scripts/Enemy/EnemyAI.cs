using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Animator animator;

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
    bool _touchingPlayer = false;

    [SerializeField] float timeToWalkAgain = 3.0f;
    float _tempTimeToWalkAgain = 0.0f;

    [SerializeField] float retryWalkTime = 3.0f;
    float _tempRetryWalkTime = 0.0f;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        timeToWalkAgain = 3.0f;
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
            if (_tempTimeToWalkAgain > 0)
            {
                _tempTimeToWalkAgain -= Time.deltaTime;
                if (animator != null)
                {
                    if (animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                    {
                        animator.Play("Idle");
                    }
                }
            }
            else
            {
                _tempTimeToWalkAgain = Random.Range(0.5f, timeToWalkAgain);
                SearchWalkPoint();
            }
        }

        if (walkPointSet)
        {
            navMeshAgent.SetDestination(walkPoint);
            if (animator != null)
            {
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                {
                    animator.Play("Run");
                }
            }

            if (_tempRetryWalkTime > 0)
            {
                _tempRetryWalkTime -= Time.deltaTime;
            }
            else
            {
                walkPointSet = false;
            }
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

        _tempRetryWalkTime = retryWalkTime;
    }

    void ChasePlayer()
    {
        if (!_touchingPlayer) navMeshAgent.SetDestination(player.position);
        _tempRetryWalkTime = retryWalkTime;

        if (animator != null)
        {
            if (!_touchingPlayer && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                animator.Play("Run");
            }
            
            if (_touchingPlayer && animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
            {
                animator.Play("Idle");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.TryGetComponent(out PlayerManager player);

        if (player)
        {
            _touchingPlayer = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _touchingPlayer = false;
    }
}
