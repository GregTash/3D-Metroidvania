using UnityEngine;
using Cinemachine;

public class CutsceneManager : MonoBehaviour
{
    CinemachineBrain _camBrain;
    Transform _camTransform;
    Animation _cutsceneAnimation;

    [SerializeField] GameObject _player;
    [SerializeField] Animator _playerAnimator;

    PlayerMovement _playerMovement;
    PlayerManager _playerManager;
    Rigidbody _playerRb;

    bool _cutsceneEnabled = false;

    public static readonly int Moving = Animator.StringToHash("Moving");

    void Start()
    {
        _camBrain = Camera.main.GetComponent<CinemachineBrain>();
        _camTransform = Camera.main.transform;
        _cutsceneAnimation = GetComponent<Animation>();

        _playerManager = _player.GetComponent<PlayerManager>();
        _playerMovement = _player.GetComponent<PlayerMovement>();
        _playerRb = _player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(_cutsceneEnabled)
        {
            if (_playerMovement.Grounded) _playerRb.isKinematic = true;

            if (!_playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                _playerAnimator.SetBool(Moving, false);
                _playerAnimator.Play("Idle");
            }

            if (!_cutsceneAnimation.isPlaying) DisableCutscene();
        }
    }

    public void EnableCutscene()
    {
        _camBrain.enabled = false;

        _camTransform.position = transform.position;
        _camTransform.rotation = transform.rotation;

        _camTransform.parent = transform;

        _cutsceneEnabled = true;

        _playerMovement.detectInput = false;
        _playerManager.allowDamage = false;
        _playerRb.velocity = Vector3.zero;

        _cutsceneAnimation.Play();
    }

    public void DisableCutscene()
    {
        _camBrain.enabled = true;

        _cutsceneEnabled = false;

        _camTransform.parent = null;

        _playerMovement.detectInput = true;
        _playerManager.allowDamage = true;
        _playerRb.isKinematic = false;
    }
}
