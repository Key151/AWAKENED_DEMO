using Unity.Cinemachine;
using UnityEngine;

public class MapTransation : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoundry;
    CinemachineConfiner2D confiner;

    [SerializeField] Direction direction;
    [SerializeField] float addPos = 2;

    private GameObject player2;
    enum Direction { Up, Down, Left, Right }

    private void Awake()
    {
        confiner = FindObjectOfType<CinemachineConfiner2D>();
        player2 = GameObject.FindGameObjectWithTag("Player2");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            confiner.BoundingShape2D = mapBoundry;
            UpdatePlayerPosition(collision.gameObject, player2);
        }
    }

    private void UpdatePlayerPosition(GameObject player, GameObject player2)
    {
        Vector3 newPos = player.transform.position;

        switch (direction)
        {
            case Direction.Up:
                newPos.y += addPos;
                break;
            case Direction.Down:
                newPos.y -= addPos;
                break;
            case Direction.Left:
                newPos.x += addPos;
                break;
            case Direction.Right:
                newPos.x -= addPos;
                break;
        }

        player.transform.position = newPos;
        player2.transform.position = newPos;
    }
}
