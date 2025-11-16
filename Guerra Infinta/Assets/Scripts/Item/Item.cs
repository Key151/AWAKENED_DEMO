using UnityEngine;

public abstract class Item : ScriptableObject
{
    public NameItem ID { get; private set; }
    public DialogueText itemName;
    public Sprite icon;
    public DialogueText description;
    public int Quantity {  get; private set; }

    public string ItemName()
    {
        return itemName.GetTextBase(LanguageManager.Instance.GetLanguage());
    }

    public string Description() 
    { 
        return description.GetTextBase(LanguageManager.Instance.GetLanguage()); 
    }

    public void Gain(int number)
    {
        Quantity += number;
    }
}