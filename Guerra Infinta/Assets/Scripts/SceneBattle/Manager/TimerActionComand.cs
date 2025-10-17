using UnityEngine;

[CreateAssetMenu(menuName = "Timer")]
public class TimerActionComand : ScriptableObject
{
    [Header("Timing")]
    [SerializeField] private float windowStart;
    [SerializeField] private float windowEnd;
    private float timer = 0f;

    public float WindowStart
    {
        get { return windowStart; }
        private set { windowStart = value; }
    }

    public float WindowEnd
    {
        get { return windowStart; }
        private set { windowStart = value; }
    }

    public float Timer
    {
        get { return timer; }
        set { timer = value; }
    }
}