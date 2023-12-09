using UnityEngine;

public class BomberAnimatorManager : MonoBehaviour
{
    [SerializeField] EnemyBow enemyBow;

    public void ThrowBomb()
    {
        enemyBow.ThrowBomb();
    }
}
