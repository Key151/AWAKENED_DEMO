using System.Collections.Generic;
using Unity.Cinemachine;
using Unity.VisualScripting;
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

    [Header("Audio")]
    [SerializeField] private string BattleSong = "Battle01";

    [Header("Black Screen")]
    [SerializeField] private GameObject screen;
    BlackScreen blackScreen;

    [Header("Enemy List")]
    [SerializeField] private List<GameObject> enemyList;


    void Start()
    {
        if (enemyList.Count == 0) enemyList = null;

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
        if (collision.gameObject.CompareTag("Menino"))
        {
            AudioManager.Instance.PlayBGM(BattleSong);
            cam.Follow = enemyTransform;
            enemyInCamera = true;

            screen.SetActive(true);
            blackScreen = screen.GetComponent<BlackScreen>();
            blackScreen.StartFadeOut();
        }
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
            PauseController.SetPause(false);
            startBattleController.StartBattle(enemyList);

        }
    }


}
