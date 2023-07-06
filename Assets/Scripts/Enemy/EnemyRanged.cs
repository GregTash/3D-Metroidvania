using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRanged : MonoBehaviour
{
    /// <summary>
    /// Behaviour for ranged enemies
    /// </summary>

    [SerializeField] EnemyAI _enemyAI;
    NavMeshAgent _navMeshAgent;
    Rigidbody _rb;
    EnemyBow _enemyBow;


    public float rotationSpeed; // rotationSpeed of Slerp
    // Start is called before the first frame update


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _enemyBow = GetComponentInChildren<EnemyBow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemyAI.playerInRange)
        {
            _navMeshAgent.isStopped =  true;
            LookAtPlayer();
        }
        else
        {
            _navMeshAgent.isStopped = false;
        }
    }

    void LookAtPlayer()
    {
        //var rotationAngle = Quaternion.LookRotation(_enemyAI.player.position - transform.position); // Gets the angle that has to be rotated.
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotationAngle, Time.deltaTime * rotationSpeed);

        var targetDirection = _enemyAI.player.position - transform.position;
        targetDirection.y = 0; // Set the Y-component to zero to restrict rotation on the Y-axis
        var rotationAngle = Quaternion.LookRotation(targetDirection);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationAngle, Time.deltaTime * rotationSpeed);

        _enemyBow.ShootAtPlayer();
    }
}
