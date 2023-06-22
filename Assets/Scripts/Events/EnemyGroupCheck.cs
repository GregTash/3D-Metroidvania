using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyGroupCheck : MonoBehaviour
{
    [SerializeField] UnityEvent onGroupClearedEvent;

    private void Update()
    {
        CheckChildren();
    }

    void CheckChildren()
    {
        if(transform.childCount <= 0)
        {
            onGroupClearedEvent.Invoke();

            Destroy(gameObject);
        }
    }
}