using UnityEngine;
using System.Collections.Generic;
using System;

public class PlayerPowerController : MonoBehaviour
{
    private List<ItemSO> powers = new List<ItemSO>();
    [SerializeField] private int startingSlots = 3;

    // Event để thông báo là power ở slot i vừa thay đổi để UI cập nhật
    public event Action<int, ItemSO> OnPowerChanged;

    // Cần phải Initialize List trước khi sử dụng
    private void Awake()
    {
        InitializeSlots(startingSlots);
    }

    private void InitializeSlots(int size)
    {
        powers.Clear();
        for (int  i = 0; i < size; i++)
        {
            powers.Add(null);
        }
    }

    public int SlotCount => powers.Count;

    // Có thể sau này mở rộng thêm Slots để chứa thêm power
    public void AddSlot()
    {
        powers.Add(null);
        OnPowerChanged?.Invoke(powers.Count - 1, null);
    }

    public bool AddPower(ItemSO power)
    {
        for (int i = 0; i < powers.Count; i++)
        {
            if (powers[i] == null)
            {
                powers[i] = power;
                OnPowerChanged?.Invoke(i, power);
                return true;
            }
        }
        return false;
    }

    public ItemSO GetPower(int index)
    {
        if (index < 0 || index >= powers.Count) return null;
        return powers[index];
    }

    public void UsePower(int index)
    {
        if (index < 0 || index >= powers.Count) return;
        if (powers[index] == null) return;
        // Logic power ở đây 

        Debug.Log($"Using power: {powers[index].name}");

        powers[index] = null;
        OnPowerChanged?.Invoke(index, null);
    }
}
