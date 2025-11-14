using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Dialogue Line")]
public class DialogueLineData : ScriptableObject, IDialogue
{
    [SerializeField] private DialogueText speakerName;
    [SerializeField] private Sprite icon;

    [TextArea(3, 5)]
    [SerializeField] private string portugueseText;

    [TextArea(3, 5)]
    [SerializeField] private string englishText;

    public string SpeakerName => speakerName.GetTextBase(LanguageManager.Instance.GetLanguage());
    public Sprite Icon => icon;

    public string GetText(Language language)
    {
        // switch statement to return the appropriate text based on the selected language
        return language switch
        {
            Language.PtBr=> portugueseText,
            Language.Eng=> englishText,
            _ => portugueseText
        };
    }
}