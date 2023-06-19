using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRanged : MonoBehaviour
{
    EnemyAI _enemyAI;
    bool alreadyAttacked;
    [SerializeField] float timeBetweenAttacks;
    [SerializeField] GameObject projectile;
    [SerializeField] float shotPower;
    public bool playerInAttackRange;


    private void Awake()
    {
        _enemyAI= GetComponent<EnemyAI>();
    }

    private void Update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, _enemyAI.sightRange, _enemyAI.playerLayer);
        if (_enemyAI.playerInRange)
        {
            ShootPlayer();
        }

    }

    void ShootPlayer()
    {
        _enemyAI.navMeshAgent.SetDestination(transform.position);

        transform.LookAt(_enemyAI.player);

        if (!alreadyAttacked)
        {
            // Attack here
            GameObject enemyShot = Instantiate(projectile, transform.position, Quaternion.identity);
            enemyShot.GetComponent<Rigidbody>().AddForce(transform.forward * shotPower, ForceMode.Impulse);
            enemyShot.GetComponent<Rigidbody>().AddForce(transform.up * 8, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
