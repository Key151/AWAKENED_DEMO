using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Dialogue Base")]
public class DialogueText : ScriptableObject
{
    [TextArea(3, 4)]
    [SerializeField] private string portugueseText;

    [TextArea(3, 4)]
    [SerializeField] private string englishText;

    public string GetTextBase(Language language)
    {
        return language switch
        {
            Language.PtBr => portugueseText,
            Language.Eng => englishText,
            _ => portugueseText
        };
    }
}