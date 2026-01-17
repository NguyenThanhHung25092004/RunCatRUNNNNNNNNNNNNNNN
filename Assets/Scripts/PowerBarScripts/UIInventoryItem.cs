// UI Slot đơn lẻ (Hiển thị icon và border)
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text slotNumberTxT;
    [SerializeField] private Image borderImage;

    private Action onClick;
    private bool empty = true;
    public bool IsEmpty => empty;

    public void Initialize(Action onClickAction)
    {
        onClick = onClickAction;
        ResetData();
        Deselect();
    }

    public void OnClick()
    {
        onClick?.Invoke();
    }

    public void ResetData()
    {
        this.itemImage.gameObject.SetActive(false);
        empty = true;
    }

    public void SetData(Sprite sprite)
    {
        this.itemImage.gameObject.SetActive(true);
        this.itemImage.sprite = sprite;
        empty = false;
    }

    public void SetSlotNumber(int slotNumber)
    {
        slotNumberTxT.text = slotNumber.ToString();
    }

    public void Select()
    {
        this.borderImage.enabled = true;
    }

    public void Deselect()
    {
        this.borderImage.enabled = false;
    }
}
