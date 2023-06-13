using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public enum ItemType
    {
        Sword,
        HealthPotion,
    }

    public ItemType itemType;
    public int amount = 1;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Sword: return ItemAssets.Instance._swordSprite;
            case ItemType.HealthPotion: return ItemAssets.Instance._healthPotionSprite;
        }
    }
}
