using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class EnemyBow : MonoBehaviour
{
    [SerializeField] EnemyAI _enemyAI;
    [SerializeField] EnemyRanged _enemyRanged;

    bool alreadyAttacked;

    [SerializeField] float timeBetweenAttacks;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject projectileSpawner;
    [SerializeField] float shotPower;

    // Start is called before the first frame update
    void Start()
    {

    }
    
    public void ShootAtPlayer()
    {
        var targetDirection = _enemyAI.player.position - transform.position;
        // targetDirection.y = 0; // Set the Y-component to zero to restrict rotation on the Y-axis
        var rotationAngle = Quaternion.LookRotation(targetDirection);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationAngle, Time.deltaTime * _enemyRanged.rotationSpeed);

        if (!alreadyAttacked)
        {
            Rigidbody _projectileRb = Instantiate(projectile, projectileSpawner.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            _projectileRb.velocity = transform.forward * shotPower;
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
