using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRanged : MonoBehaviour
{
    [SerializeField] EnemyAI _enemyAI;
    Rigidbody _rb;
    NavMeshAgent _navMeshAgent;

    bool alreadyAttacked;

    [SerializeField] float timeBetweenAttacks;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject projectileSpawner;
    [SerializeField] float rotationSpeed; // rotationSpeed of Slerp
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemyAI.playerInRange)
        {
            _navMeshAgent.isStopped =  true;
            Shooting();
        }
        else
        {
            _navMeshAgent.isStopped = false;
        }
    }

    void Shooting()
    {
        //var rotationAngle = Quaternion.LookRotation(_enemyAI.player.position - transform.position); // Gets the angle that has to be rotated.
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotationAngle, Time.deltaTime * rotationSpeed);

        var targetDirection = _enemyAI.player.position - transform.position;
        targetDirection.y = 0; // Set the Y-component to zero to restrict rotation on the Y-axis
        var rotationAngle = Quaternion.LookRotation(targetDirection);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationAngle, Time.deltaTime * rotationSpeed);

        if (!alreadyAttacked)
        {
            Rigidbody _projectileRb = Instantiate(projectile, projectileSpawner.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            _projectileRb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
