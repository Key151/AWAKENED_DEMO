using UnityEngine;

[CreateAssetMenu(menuName = "Timer")]
public class TimerActionComand : ScriptableObject
{
    [Header("Timing")]
    [SerializeField] private float windowStart;
    [SerializeField] private float windowEnd;
    private float timerA = 0f;

    public float WindowStart
    {
        get { return windowStart; }
    }

    public float WindowEnd
    {
        get { return windowEnd; }
    }

    public float Timer
    {
        get { return timerA; }
        set { timerA = value; }
    }
}