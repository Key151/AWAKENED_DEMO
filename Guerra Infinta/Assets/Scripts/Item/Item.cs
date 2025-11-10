using UnityEngine;

public abstract class Item : ScriptableObject
{
    public NameItem id;
    public DialogueLineData itemName;
    public Sprite icon;
    public DialogueLineData description;
    public int quantity;

    public string ItemName()
    {
        return itemName.GetText(LanguageManager.Instance.GetLanguage());
    }

    public string Description() 
    { 
        return description.GetText(LanguageManager.Instance.GetLanguage()); 
    }
}