using UnityEngine;
using UnityEngine.InputSystem;
public class ScratchController : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] GameObject scratchVFX;

    Collider _scratchCollider;

    [SerializeField] AudioSource hitSound;
    [SerializeField] AudioSource swingSound;

    [SerializeField] float swingDuration;
    [SerializeField] float hitboxDuration;
    float _tempSwingDuration;
    float _tempHitboxDuration;

    bool allowSwing = true;
    bool allowHitbox = false;

    [SerializeField] int scratchDamage = 10;

    private void Start()
    {
        scratchVFX.SetActive(false);
        _scratchCollider = GetComponent<Collider>();
    }
    private void OnEnable()
    {
        playerInput.actions["Attack"].started += OnSwing;
    }
    private void OnDisable()
    {
        playerInput.actions["Attack"].started -= OnSwing;
    }
    void Update()
    {
        SwingCooldown();
        HitboxDuration();
    }
    void OnSwing(InputAction.CallbackContext context)
    {
        if (allowSwing)
        {
            Swing();
        }
    }
    void Swing()
    {
        scratchVFX.SetActive(true);
        _scratchCollider.enabled = true;
        swingSound.Play();
        _tempSwingDuration = swingDuration;
        _tempHitboxDuration = hitboxDuration;
        allowSwing = false;
        allowHitbox = true;
    }
    void SwingCooldown()
    {
        if (!allowSwing && _tempSwingDuration > 0)
        {
            _tempSwingDuration -= Time.deltaTime;
        }
        else if (!allowSwing && _tempSwingDuration <= 0)
        {
            scratchVFX.SetActive(false);

            allowSwing = true;
        }
    }
    void HitboxDuration()
    {
        if (allowHitbox && _tempHitboxDuration > 0)
        {
            _tempHitboxDuration -= Time.deltaTime;
        }
        else if (allowHitbox && _tempHitboxDuration <= 0)
        {
            _scratchCollider.enabled = false;
            allowHitbox = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out DamageTarget damageTarget);
        if (damageTarget)
        {
            damageTarget.TakeDamage(scratchDamage);
            hitSound.Play();
        }
    }
}