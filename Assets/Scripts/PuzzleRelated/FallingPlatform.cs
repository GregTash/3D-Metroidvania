using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    AudioSource _audioSource;
    private Rigidbody _rb;
    [SerializeField] private float timeTilFall;
    [SerializeField] private float timer;

    [SerializeField] private float timeTillRespawn = 3.0f;
    float _tempTimeTillRespawn = 0.0f;

    private bool triggeredDrop;
    private bool _dropping;
    private bool _playedAudio;

    private Vector3 origPosition;
    [SerializeField] private GameObject spawnInObject;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _tempTimeTillRespawn = timeTillRespawn;
        origPosition = transform.position;
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (triggeredDrop)
        {
            if (!_playedAudio)
            {
                _audioSource.Play();
                _playedAudio = true;
            }

            timer += Time.deltaTime;

            if (timer >= timeTilFall)
            {
                DropPlatform();
            }
        }

        if (_dropping)
        {
            if (_tempTimeTillRespawn > 0)
            {
                _tempTimeTillRespawn -= Time.deltaTime;
            }
            else
            {
                RespawnPlatform();
                _tempTimeTillRespawn = timeTillRespawn;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        other.transform.TryGetComponent(out PlayerManager playerManager);
        other.transform.TryGetComponent(out RespawnPlatform respawnPlatform);
        
        if (playerManager)
        {
            triggeredDrop = true;
        }
    }

    void RespawnPlatform()
    {
        transform.position = origPosition;
        _rb.useGravity = false;
        _rb.constraints |= RigidbodyConstraints.FreezePositionY;
        timer = 0;
        _dropping = false;
        _playedAudio = false;
    }

    void DropPlatform()
    {
        _rb.useGravity = true;
        _rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
        _rb.mass = 2000f;
        triggeredDrop = false;
        _dropping = true;
    }
}
