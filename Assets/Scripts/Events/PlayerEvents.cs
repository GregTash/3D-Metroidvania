using UnityEngine;

public class PlayerEvents
{
    public delegate void UseEquipped();
    public delegate void EquipItem(Transform objectToMove);

    public static UseEquipped onUseEquippedEvent;
    public static EquipItem onEquipItemEvent;
}
