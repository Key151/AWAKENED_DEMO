using UnityEngine;

public class ReturnButton : MonoBehaviour
{

    private OptionPanel optionPanel;

    void Start()
    {
        optionPanel = FindAnyObjectByType<OptionPanel>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (this.gameObject.activeSelf)
            {
                optionPanel.OnReturnButton();
            }
        }
    }
}
