using System.Diagnostics;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private UIInventory inventoryUI;
    public int inventorySize = 3;

    private void Start()
    {
        inventoryUI.InitializeInventoryUI(inventorySize);

        inventoryUI.OnInventoryItemSelected += HandleEquipItem;
    }

    private void HandleEquipItem(int itemIndex)
    {
        UnityEngine.Debug.Log($"Equipping item from slot {itemIndex}");
    }

    private void Update()
    {
        for (int i = 0; i < inventorySize; i++)
        {
            if (i < inventorySize && Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                inventoryUI.SelectItemByIndex(i);
                break;
            }
        }
    }
}
