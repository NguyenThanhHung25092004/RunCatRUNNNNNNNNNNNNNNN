using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private UIInventoryItem itemPrefab;
    [SerializeField] private RectTransform contentPanel;

    List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();

    public event Action<int> OnInventoryItemSelected;

    public void InitializeInventoryUI (int inventorySize)
    {
        for (int i = 0; i < inventorySize; i++)
        {
            UIInventoryItem newItem = Instantiate(itemPrefab, contentPanel);
            listOfUIItems.Add(newItem);
        }
    }

    public void SelectItemByIndex(int index)
    {
        if (index < 0 || index >= listOfUIItems.Count) return;

        UIInventoryItem selectedItem = listOfUIItems[index];

        //if (selectedItem.IsEmpty)
        //{
        //    return;
        //}

        foreach (var item in listOfUIItems)
        {
            item.Deselect();
        }

        selectedItem.Select();
        OnInventoryItemSelected?.Invoke(index);
    }
}
