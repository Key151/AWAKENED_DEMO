using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3 (target.position.x, target.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position,newPos,followSpeed*Time.deltaTime);
    }
}
