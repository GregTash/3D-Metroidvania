using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEquipable : MonoBehaviour
{
    [SerializeField] float throwForce = 15f;
    [SerializeField] GameObject thrownBomb;
    Transform _playerTransform;
    Transform _itemSocketTransform;
    EquippedItemManager equippedItemManager;

    bool _equipped;

    private void OnEnable()
    {
        PlayerEvents.onEquipItemEvent += Equip;
        PlayerEvents.onUseEquippedEvent += UseBomb;
    }

    private void OnDisable()
    {
        PlayerEvents.onEquipItemEvent -= Equip;
        PlayerEvents.onUseEquippedEvent -= UseBomb;
    }

    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _itemSocketTransform = _playerTransform.GetComponentInChildren<EquippedItemManager>().transform;
        equippedItemManager = _itemSocketTransform.GetComponent<EquippedItemManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player" && equippedItemManager.equipped == false)
        {
            PlayerEvents.onEquipItemEvent?.Invoke(transform);
        }
    }

    void Equip(Transform objectToMove)
    {
        if (transform != objectToMove) return;

        _equipped = true;

        GetComponent<SinWave>().enabled = false;

        transform.position = _itemSocketTransform.position;
        transform.SetParent(_itemSocketTransform);

        equippedItemManager.equipped = true;
    }

    void UseBomb()
    {
        if (!_equipped) return;

        GameObject instBomb = Instantiate(thrownBomb, _playerTransform.position + new Vector3(0f, 1f, 0f), _playerTransform.rotation);

        instBomb.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * throwForce, ForceMode.Impulse);

        equippedItemManager.equipped = false;

        Destroy(gameObject);
    }
}
