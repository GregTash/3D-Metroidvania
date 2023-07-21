using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    Inventory _inventory;
    Transform _itemSlotContainer;
    Transform _itemSlotTemplate;

    private void Awake()
    {
        _itemSlotContainer = transform.Find("ItemSlotContainer");
        _itemSlotTemplate = _itemSlotContainer.Find("ItemSlotTemplate");
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetInventory(Inventory inventory)
    {
        this._inventory = inventory;

        _inventory.OnItemListChanged += Inventory_OnItemListChanged;

        RefreshInventoryItems();
    }

    void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    void RefreshInventoryItems()
    {
        foreach(Transform child in _itemSlotContainer)
        {
            if (child == _itemSlotTemplate) continue;

            Destroy(child.gameObject);
        }

        int x = 0, y = 0;
        float itemSlotCellSize = 120f;

        foreach(Item item in _inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(_itemSlotTemplate, _itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);

            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();

            TMP_Text amount = itemSlotRectTransform.Find("Amount").GetComponent<TMP_Text>();
            amount.text = item.amount.ToString();
            if(!item.IsStackable())
            {
                amount.text = "";
            }

            x++;

            if (x > 5)
            {
                x = 0;
                y--;
            }
        }
    }
}
