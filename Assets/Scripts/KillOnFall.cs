using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnFall : MonoBehaviour
{
    Vector2 _lastPos;
    [SerializeField] float thisObjHeight = 2f;
    public bool _grounded = false;
    [SerializeField] LayerMask ignoreLayers;
    [SerializeField] float timeBeforeDeath = 5f;
    float _timeBeforeDeath;

    private void Awake()
    {
        _timeBeforeDeath = timeBeforeDeath;
    }

    void Update()
    {
        _lastPos = transform.position;

        _grounded = Physics.Raycast(transform.localPosition, Vector3.down, out RaycastHit hit, thisObjHeight * 0.5f + 0.2f, ~ignoreLayers);

        if(!_grounded)
        {
            _timeBeforeDeath -= Time.deltaTime;
        }
        else
        {
            _timeBeforeDeath = timeBeforeDeath;
        }

        if(_timeBeforeDeath <= 0)
        {
            Destroy(gameObject);
        }
    }
}