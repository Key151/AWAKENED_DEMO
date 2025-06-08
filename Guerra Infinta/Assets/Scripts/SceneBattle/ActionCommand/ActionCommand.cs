
using UnityEngine;

public class ActionCommand : MonoBehaviour
{
    public float windowStart = 0.5f;
    public float windowEnd = 1.0f;

    private float timer = 0f;
    private bool commandActive = false;
    private bool inputReceived = false;
    private System.Action<bool> onComplete;

    public void StartActionCommand(System.Action<bool> callback)
    {
        timer = 0f;
        commandActive = true;
        inputReceived = false;
        onComplete = callback;
    }

    void Update()
    {
        if (!commandActive) return;

        timer += Time.deltaTime;
        Debug.Log($"tempo atual:{timer}");

        if (Input.GetKeyDown(KeyCode.Return))
        {
            bool success = timer >= windowStart && timer <= windowEnd;
            CompleteCommand(success);
        }

        if (timer > windowEnd && !inputReceived)
        {
            CompleteCommand(false);
        }
    }

    void CompleteCommand(bool success)
    {
        commandActive = false;
        inputReceived = true;
        onComplete?.Invoke(success);
    }
}