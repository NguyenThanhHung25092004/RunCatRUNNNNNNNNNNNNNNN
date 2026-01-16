using UnityEngine;
using System.Collections.Generic;

public class PlayerPowerController : MonoBehaviour
{
    private List<ItemSO> powers = new List<ItemSO>();
    private int limitPowers = 3;
    
    // Cần phải Initialize List trước khi sử dụng 
    public bool AddPower(ItemSO power)
    {
        for (int i = 0; i < limitPowers; i++)
        {
            if (powers[i] == null)
            {
                powers[i] = power;
                return true;
            }
        }
        return false;
    }

    public ItemSO GetPower(int index)
    {
        if (index < 0 || index >= limitPowers) return null;
        return powers[index];
    }

    public void UsePower(int index)
    {
        if (index < 0 || index >= limitPowers) return;
        if (powers[index] == null) return;
        // Logic power ở đây 

        Debug.Log($"Using power: {powers[index].name}");

        powers[index] = null;
    }
}
