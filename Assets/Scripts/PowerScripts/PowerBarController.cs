using System.Runtime.CompilerServices;
using UnityEngine;

// Để làm trung gian giữa UI và PlayerPowerController
public class PowerBarController : MonoBehaviour
{
    [SerializeField] private PlayerPowerController playerPower;
    [SerializeField] private UIInventory uiInventory;

    private void Start()
    {
        uiInventory.InitializeInventoryUI(playerPower.SlotCount);
        playerPower.OnPowerChanged += (index, power) =>
        {
            uiInventory.UpdateSlot(index, power);
        };
    }

    private void Update()
    {
        for (int i = 0; i < playerPower.SlotCount; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i)) 
            {
                uiInventory.SelectItemByIndex(i);
                break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            int index = uiInventory.SelectedIndex;
            if (index >= 0)
            {
                playerPower.UsePower(index);
            }
        }
    }
}
