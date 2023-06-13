using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    public Transform pfItemPickup;

    public Sprite _swordSprite;
    public Sprite _healthPotionSprite;

    private void Awake()
    {
        Instance = this;
    }
}
