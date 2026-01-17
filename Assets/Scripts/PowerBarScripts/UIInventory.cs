// Chọn slot, sync UI
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private UIInventoryItem itemPrefab;
    [SerializeField] private RectTransform contentPanel;

    private List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();
    private int selectedIndex = -1;
    public void InitializeInventoryUI (int inventorySize)
    {
        for (int i = 0; i < inventorySize; i++)
        {
            int index = i;
            UIInventoryItem newPower = Instantiate(itemPrefab, contentPanel);
            newPower.Initialize(() => SelectItemByIndex(index));
            newPower.SetSlotNumber(index + 1);
            listOfUIItems.Add(newPower);
        }
    }

    public void UpdateSlot(int index, ItemSO power)
    {
        if (index < 0 || index >= listOfUIItems.Count) return;

        if (power == null)
        {
            listOfUIItems[index].ResetData();
        } else
        {
            listOfUIItems[index].SetData(power.ItemImage);
        }
    }

    public void SelectItemByIndex(int index)
    {
        if (index < 0 || index >= listOfUIItems.Count) return;

        if (selectedIndex >= 0)
        {
            listOfUIItems[selectedIndex].Deselect();
        }

        selectedIndex = index;
        listOfUIItems[index].Select();
    }

    public int SelectedIndex => selectedIndex;
}
