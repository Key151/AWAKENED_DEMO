using UnityEngine;

public abstract class Item : ScriptableObject
{
    [SerializeField] protected int quantity;
    public NameItem ID { get; private set; }
    public DialogueText itemName;
    public Sprite icon;
    public DialogueText description;
    public int Quantity => quantity;

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
        quantity += number;
    }

    public void Lose(int number)
    {
        quantity = Mathf.Max(0, quantity - number);
    }
}