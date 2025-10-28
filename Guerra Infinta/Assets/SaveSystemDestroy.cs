using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "TelaInicial")
        {
            SceneManager.sceneLoaded -= OnSceneLoad;
            Destroy(gameObject);
        }
    }
}
