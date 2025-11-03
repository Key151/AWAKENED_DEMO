using UnityEngine;
using UnityEngine.Tilemaps;

public class WalkBehind : MonoBehaviour
{
    Tilemap tilemap;
    private float transparentAlpha = 0.3f;

    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Menino"))
        {
            Vector3Int tilePos = tilemap.WorldToCell(collision.transform.position);
            Color color = tilemap.GetColor(tilePos);
            color.a = transparentAlpha;
            tilemap.SetColor(tilePos, color);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Menino"))
        {
            Vector3Int tilePos = tilemap.WorldToCell(collision.transform.position);
            Color color = tilemap.GetColor(tilePos);
            color.a = 1f;
            tilemap.SetColor(tilePos, color);
        }
    }
}
