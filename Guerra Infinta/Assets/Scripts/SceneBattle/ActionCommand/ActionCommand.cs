
using UnityEngine;

public class ActionCommand : MonoBehaviour
{
    [Header("Timing")]
    [SerializeField] private float windowStart;
    [SerializeField] private float windowEnd;

    private float timer = 0f;
    private bool commandActive = false;
    private bool inputReceived = false;
    private System.Action<bool> onComplete;

    public void StartActionCommand(System.Action<bool> callback)
    {
        timer = 0f;
        commandActive = true;
        inputReceived = false;
        onComplete = callback; // armazenou a funcao Action<bool>, nesse caso armazena a lambda
    }

    void Update()
    {
        if (!commandActive) return;

        timer += Time.deltaTime;
        //Debug.Log($"tempo atual:{timer}");

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
        onComplete?.Invoke(success);  //o Invoke nao e obrigatorio, envia success para o result da lambda
    }
}