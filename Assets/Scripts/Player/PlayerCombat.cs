using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] GameObject swordObject;
    SwordCollision _swordCollision;
    [SerializeField] float appearForSeconds;
    [SerializeField] int weaponDamage;
    public bool hasHitEnemy;

    [SerializeField] PlayerInput PlayerInput;

    // Start is called before the first frame update
    void Start()
    {
        _swordCollision = swordObject.GetComponent<SwordCollision>();
        PlayerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        InputAction attackKeyPressed = PlayerInput.actions["Attack"];

        attackKeyPressed.started += OnSwing;

        attackKeyPressed.Enable();
    }

    private void OnDisable()
    {
        InputAction attackKeyPressed = PlayerInput.actions["Attack"];

        attackKeyPressed.Disable();

        attackKeyPressed.started -= OnSwing;
    }

    void OnSwing(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Swing();
        }
    }

    void Swing()
    {
        IDamageable damageable;
        Debug.Log("Swing function working");
        StartCoroutine(IActivateSword());
        if (_swordCollision.hitEnemy != null)
        {
            _swordCollision.hitEnemy.TryGetComponent(out DamageTarget damageTarget);
            damageable = damageTarget.GetComponent<IDamageable>();
            damageable.TakeDamage(weaponDamage);

        }
    }

    IEnumerator IActivateSword()
    {
        Debug.Log("Enumerator is working");
        swordObject.SetActive(true);
        yield return new WaitForSeconds(appearForSeconds);
        swordObject.SetActive(false);
    }
}
