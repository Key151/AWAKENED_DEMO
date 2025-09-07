using UnityEngine;

public class ReturnButton : MonoBehaviour
{

    private BattleSystem battleSystem;

    void Start()
    {
        battleSystem = GameObject.Find("BattleSystem").GetComponent<BattleSystem>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (this.gameObject.activeSelf)
            {
                battleSystem.OnReturnButton();
            }
        }
    }
}
