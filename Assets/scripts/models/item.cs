using UnityEngine;

public enum SlotTag { None, Head, Chest, Legs, Feet}

[CreateAssetMenu(menuName = "RPG 2D/Item")]

public class item : ScriptableObject
{
    public Sprite sprite;
    public SlotTag itemTag;
    public GameObject prefab;
    public int str;
    public int res;

}
