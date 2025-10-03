using UnityEngine;

public class ReturnButton : MonoBehaviour
{

    OptionPanel optionPanel;

    void Start()
    {
        optionPanel = GameObject.Find("Canvas(Front)").GetComponent<OptionPanel>();
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
