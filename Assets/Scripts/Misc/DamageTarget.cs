using Unity.Collections;
using UnityEngine;

public class DamageTarget : MonoBehaviour, IDamageable
{
    public int maxHealth;
    public int Health { get; private set; }
    [SerializeField] GameObject[] gameObjectsOnDeath;

    void Start()
    {
        Health = maxHealth;
    }

    public void Hit(int damageAmount)
    {
        Health -= damageAmount;

        if (Health <= 0)
        {
            int rand = Random.Range(0, gameObjectsOnDeath.Length);
            if (gameObjectsOnDeath[rand] != null) Instantiate(gameObjectsOnDeath[rand], new Vector3(transform.position.x, transform.position.y + gameObjectsOnDeath[rand].transform.position.x, transform.position.z), gameObjectsOnDeath[rand].transform.rotation);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        Hit(damageAmount);
    }
}
