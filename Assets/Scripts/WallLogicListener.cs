using UnityEngine;

public class WallLogicListener : MonoBehaviour
{
    [HideInInspector] public WallLogic wallLogicSource;
    [HideInInspector] public bool alreadyCollided;

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.TryGetComponent(out PlayerManager player);

        if (player)
        {
            if (alreadyCollided) return;

            wallLogicSource.timeBeforeResetPlaceholder = wallLogicSource.timeBeforeReset;

            wallLogicSource.collidedObjectsCount += 1;

            alreadyCollided = true;
        }
    }
}