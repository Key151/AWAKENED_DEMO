using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Dialogue/Dialogue Sequence")]
public class DialogueSequenceData : ScriptableObject
{
    public List<DialogueLineData> dialogueLines;
}