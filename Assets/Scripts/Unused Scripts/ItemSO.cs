using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
public class ItemSO : ScriptableObject
{
    public int ID => GetInstanceID();

    [field: SerializeField] public string Name { get; set; }
    [field: SerializeField] public Sprite ItemImage { get; set; }
}
