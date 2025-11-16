using UnityEngine;

public abstract class Item : ScriptableObject
{
    public NameItem id;
    public DialogueText itemName;
    public Sprite icon;
    public DialogueText description;
    public int quantity;

    public string ItemName()
    {
        return itemName.GetTextBase(LanguageManager.Instance.GetLanguage());
    }

    public string Description() 
    { 
        return description.GetTextBase(LanguageManager.Instance.GetLanguage()); 
    }
}