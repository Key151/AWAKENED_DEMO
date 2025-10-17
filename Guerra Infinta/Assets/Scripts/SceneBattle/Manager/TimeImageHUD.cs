using UnityEngine;
using UnityEngine.UI;

public class TimeIcon : ShowIcon
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TimerActionComand TimeAction;
    public void StartActionIcon()
    {
        isActive = true;
        SetTimer(TimeAction.WindowEnd);
        popUp.transform.position = target.position; // posiciona no inimigo, se for dinamico precisa colocar no show()
        Debug.Log($"Timer={TimeAction.Timer}, Start={TimeAction.WindowStart}, End={TimeAction.WindowEnd}");
    }

    protected override void Show()
    {
        if (!isActive) return;

        base.Show();

        bool success = TimeAction.Timer >= TimeAction.WindowStart && TimeAction.Timer <= TimeAction.WindowEnd;

        Debug.Log($"Success={success}");

        if (success) popUp.SetActive(true);
        else popUp.SetActive(false);
    }
}