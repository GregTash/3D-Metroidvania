using UnityEngine;
using UnityEngine.Events;

public class EnableCutsceneOnTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent onCutsceneTriggerEvent;

    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out PlayerManager playerManager);

        if (playerManager)
        {
            onCutsceneTriggerEvent.Invoke();
        }
    }
}
