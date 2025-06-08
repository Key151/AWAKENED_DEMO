using UnityEngine;

public interface IDialogue
{
    string SpeakerName { get; }
    Sprite Icon { get; }
    string GetText(Language language);

}
