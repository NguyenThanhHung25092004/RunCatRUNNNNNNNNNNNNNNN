using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
public abstract class ItemSO : ScriptableObject
{
    [field: SerializeField] public string Name { get; set; }
    [field: SerializeField] public Sprite ItemImage { get; set; }

    public abstract void Activate(PlayerPowerController player);
}
