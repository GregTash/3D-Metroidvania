using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StompPower : MonoBehaviour
{
    [SerializeField] float diveForce = 30f;
    PlayerMovement _playerMovement;
    Animation _animation;
    int _stompDamage = 10;
    Collider _collider;
    Rigidbody _playerRb;
    AudioSource _audioSource;
    [SerializeField] AudioSource swooshAudioSource, stompAudioSource;

    struct Enemy
    {
        public GameObject enemyGO;
        public bool alreadyHit;
    };

    List<Enemy> _enemies = new List<Enemy>();
    [SerializeField] PlayerInput playerInput;
    bool _stomping = false;

    float closestObjectDistance;
    [SerializeField] LayerMask ignoreLayers;

    private void OnEnable()
    {
        InputAction stompKeyPress = playerInput.actions["Stomp"];

        stompKeyPress.started += Stomp;
    }

    private void OnDisable()
    {
        InputAction stompKeyPress = playerInput.actions["Stomp"];

        stompKeyPress.started -= Stomp;
    }

    private void Start()
    {
        _animation = GetComponent<Animation>();
        _collider = GetComponent<Collider>();
        _audioSource = GetComponent<AudioSource>();

        _playerRb = transform.root.GetComponent<Rigidbody>();
        _playerMovement = transform.root.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(!_animation.isPlaying) _collider.enabled = false;

        CalculateClosestObject();

        if (_stomping)
        {
            _playerRb.velocity = new Vector3(0, -diveForce, 0);

            if (!_animation.isPlaying && _playerMovement.TouchingSomething)
            {
                stompAudioSource.Play();
                _animation.Play();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IDamageable>() != null)
        {
            Enemy newEnemy = new Enemy
            {
                enemyGO = other.gameObject,
                alreadyHit = false
            };

            foreach(Enemy enemy in _enemies)
            {
                if(enemy.enemyGO == other.gameObject)
                {
                    if (enemy.alreadyHit) return;
                }
            }

            other.GetComponent<IDamageable>().TakeDamage(_stompDamage);
            _audioSource.Play();

            newEnemy.alreadyHit = true;

            _enemies.Add(newEnemy);
        }
    }

    void Stomp(InputAction.CallbackContext context)
    {
        if (_stomping) return;
        if (closestObjectDistance < 6f) return;

        swooshAudioSource.Play();
        _stomping = true;
    }

    void StopStomp()
    {
        _stomping = false;
    }

    void CalculateClosestObject()
    {
        Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity, ~ignoreLayers);

        if(hit.transform == null)
        {
            closestObjectDistance = 999f;
            return;
        }

        closestObjectDistance = Vector3.Distance(transform.position, hit.point);
    }

    void ClearEnemyList()
    {
        _enemies.Clear();
    }
}
