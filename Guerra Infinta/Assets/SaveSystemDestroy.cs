using UnityEngine;

public class SaveSystemDestroy : MonoBehaviour
{
    public static SaveSystemDestroy Instance { get; private set; }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void DestroySaveSystem()
    {
        Destroy(gameObject);
    }
}
