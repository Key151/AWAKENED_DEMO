using UnityEngine;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private GameObject audioManagerPrefab;

    void Awake()
    {
        if (AudioManager.Instance == null)
        {
            Instantiate(audioManagerPrefab);
        }
    }
}
