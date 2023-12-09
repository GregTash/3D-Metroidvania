using UnityEngine;

public class EnemyBow : MonoBehaviour
{
    [SerializeField] EnemyAI _enemyAI;
    [SerializeField] EnemyRanged _enemyRanged;

    bool _alreadyAttacked = true;

    [SerializeField] float timeBetweenAttacks;
    [SerializeField] GameObject projectile;
    [SerializeField] float shotPower;

    [SerializeField] Animator animator;

    private void Start()
    {
        Invoke(nameof(ResetAttack), timeBetweenAttacks);
    }

    public void ShootAtPlayer()
    {
        var targetDirection = _enemyAI.player.position - transform.position;
        // targetDirection.y = 0; // Set the Y-component to zero to restrict rotation on the Y-axis
        var rotationAngle = Quaternion.LookRotation(targetDirection);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationAngle, Time.deltaTime * _enemyRanged.rotationSpeed);

        if (!_alreadyAttacked)
        {
            animator.Play("Jump");
            
            _alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    public void ThrowBomb()
    {
        Rigidbody _projectileRb = Instantiate(projectile, transform.position + new Vector3(0, 2, 0), Quaternion.identity).GetComponent<Rigidbody>();
        _projectileRb.velocity = transform.forward * shotPower;
    }

    void ResetAttack()
    {
        _alreadyAttacked = false;
    }
}
