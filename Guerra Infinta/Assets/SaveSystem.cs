using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
