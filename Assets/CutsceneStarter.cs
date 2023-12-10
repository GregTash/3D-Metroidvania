using UnityEngine;
using UnityEngine.Events;

public class CutsceneStarter : MonoBehaviour
{
    [SerializeField] UnityEvent cutsceneStarter;

    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out PlayerManager player);

        if (player)
        {
            cutsceneStarter.Invoke();
        }
    }

    public void DestroyCutsceneTrigger()
    {
        Destroy(gameObject);
    }
}
