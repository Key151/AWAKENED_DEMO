using UnityEngine;

public class ShowIcon: MonoBehaviour
{
    [SerializeField] protected GameObject popUp;
    [SerializeField] protected Transform target;
    [SerializeField] protected float timer;
    protected bool isActive = false;
    private float baseTimer;

    protected void Start()
    {
        popUp.SetActive(false);
        baseTimer = timer;
    }

    public void SetTimer(float newTime)
    {
        timer = newTime;
        baseTimer = newTime; // atualiza tambem o tempo-base
    }

    protected virtual void Show()
    {
        if (!isActive) return;

        // posiciona no inimigo
        popUp.transform.position = target.position;

        // Conta o tempo
        timer -= Time.deltaTime;

        //Acaba o tempo some
        if (timer <= 0f)
        {
            timer = baseTimer;
            popUp.SetActive(false);
            isActive = false;
        }
    }

    private void Update()
    {
        Show();
    }
}
