using UnityEngine;

public abstract class Item: ScriptableObject
{
    public NameItem id;
    public string itemName;
    //public Sprite icon;
    public string description;
    public int quantity;
}