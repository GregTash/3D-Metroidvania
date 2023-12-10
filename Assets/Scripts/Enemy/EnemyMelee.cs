using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    [SerializeField] GameObject scratchVFX;
    [SerializeField] int damageAmount = 5;
    [SerializeField] float timeBetweenAttack = 1.0f;
    float _tempTimeBetweenAttack = 0.0f;

    bool _scratchVfxEnabled = false;
    [SerializeField] float scratchVfxTimer = 1.0f;
    float _tempScratchVfxTimer = 0.0f;

    AudioSource _audioSource;
    bool _takenDamage;
    PlayerManager _player;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        _tempTimeBetweenAttack = timeBetweenAttack;
        _tempScratchVfxTimer = scratchVfxTimer;
    }

    private void Update()
    {
        if (_player != null)
        {
            if (!_takenDamage)
            {
                Attack();
            }
        }

        if (_takenDamage)
        {
            if (_tempTimeBetweenAttack > 0)
            {
                _tempTimeBetweenAttack -= Time.deltaTime;
            }
            else
            {
                _tempTimeBetweenAttack = timeBetweenAttack;
                _takenDamage = false;
            }
        }

        if (_scratchVfxEnabled)
        {
            if (_tempScratchVfxTimer > 0)
            {
                _tempScratchVfxTimer -= Time.deltaTime;
            }
            else
            {
                _tempScratchVfxTimer = scratchVfxTimer;
                scratchVFX.SetActive(false);
                _scratchVfxEnabled = false;
            }
        }
    }

    void Attack()
    {
        _player.GetComponent<IDamageable>().TakeDamage(damageAmount); // Runs TakeDamage
        _audioSource.Play();
        _takenDamage = true;

        scratchVFX.SetActive(true);
        _scratchVfxEnabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.TryGetComponent(out PlayerManager playerManager); // checks for playerManager
        if (playerManager)
        {
            if (!_takenDamage)
            {
                _player = playerManager;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _player = null;
    }
}
