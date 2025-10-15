using Unity.Cinemachine;
using UnityEngine;

public class EnemyEncounter : MonoBehaviour
{

    [Header("Camera Settings")]
    private CinemachineCamera cam;
    private float addDutch = 5f;
    private float removeOrtho = 0.1f;

    [Header("Enemy Settings")]
    private Transform enemyTransform;
    private bool enemyInCamera;

    [Header("Battle")]
    private StartBattleController startBattleController;


    void Start()
    {
        startBattleController = FindAnyObjectByType<StartBattleController>();
        cam = FindAnyObjectByType<CinemachineCamera>();
        enemyTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyInCamera)
        {
            CameraMovement();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cam.Follow = enemyTransform;
        enemyInCamera = true;
    }

    private void CameraMovement()
    {
        PauseController.SetPause(true);
        cam.Lens.Dutch += addDutch;
        if(cam.Lens.Dutch >= 30 || cam.Lens.Dutch <= -30)
        {
            addDutch *= -1;
        }
        if(cam.Lens.OrthographicSize > 1f)
        {
            cam.Lens.OrthographicSize -= removeOrtho;
        }
        else
        {
            cam.Lens.OrthographicSize = 1f;
            startBattleController.StartBattle();

        }
    }


}
