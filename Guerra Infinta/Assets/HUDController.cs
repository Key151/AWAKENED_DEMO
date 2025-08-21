using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{

    [SerializeField] private Text nameTurn;

    public void ChanegenameTurn(Text turnName)
    {
        nameTurn.text = turnName.text;
    }
}
