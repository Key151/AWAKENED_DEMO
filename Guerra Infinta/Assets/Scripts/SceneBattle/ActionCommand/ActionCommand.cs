
using UnityEngine;

public class ActionCommand : MonoBehaviour
{
    [Header("Timing")]
    [SerializeField] private TimerActionComand TimeAction;

    private bool commandActive = false;
    private bool inputReceived = false;
    private System.Action<bool> onComplete;
    
    private UnitEnemy enemy;

    public void StartActionCommand(System.Action<bool> callback, UnitEnemy unitEnemy)
    {
        TimeAction.Timer = 0f;
        enemy = unitEnemy;
        Debug.Log($"Timer={TimeAction.Timer}, Start={TimeAction.WindowStart}, End={TimeAction.WindowEnd}");
        commandActive = true;
        inputReceived = false;
        onComplete = callback; // armazenou a funcao Action<bool>, nesse caso armazena a lambda
    }

    void Update()
    {
        if (!commandActive) return;

        TimeAction.Timer += Time.deltaTime;
        //Debug.Log($"tempo atual:{timer}");

        if (enemy.ClickEnemy())
        {
            bool success = TimeAction.Timer >= TimeAction.WindowStart && TimeAction.Timer <= TimeAction.WindowEnd;
            TimeAction.Timer = 0f;
            CompleteCommand(success);
        }

        /*if (Input.GetKeyDown(KeyCode.Return))
        {
            bool success = TimeAction.Timer >= TimeAction.WindowStart && TimeAction.Timer <= TimeAction.WindowEnd;
            TimeAction.Timer = 0f;
            CompleteCommand(success);
        }*/

        if (TimeAction.Timer > TimeAction.WindowEnd && !inputReceived)
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