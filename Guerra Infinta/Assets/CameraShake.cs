using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private Transform hudTransform;
    private Vector2 hudOrigem;

    private float duration = 0.5f;
    private float magnetute = 0.2f;

    private void Start()
    {
        hudOrigem = hudTransform.localPosition;
    }

    public void StartShake()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float time = 0f;

        while (time < duration)
        {
            float x = Random.Range(-1f, 1f) * magnetute;
            float y = Random.Range(-1f, 1f) * magnetute;

            hudTransform.localPosition = hudOrigem + new Vector2(x, y);

            time += Time.deltaTime;
            yield return null;
        }
        hudTransform.localPosition = hudOrigem;
    }

}
