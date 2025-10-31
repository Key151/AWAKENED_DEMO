using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class StateObjectsController : MonoBehaviour
{
    public static StateObjectsController Instance {  get; private set; }

    [SerializeField] private List<GameObject> StartGame;
    [SerializeField] private List<GameObject> TutorialBattle;

    void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        DisableAllLists();
        ChangeStateObjects(GameStateController.Instance.GetCurrentState());
    }

    public void ChangeStateObjects(string state)
    {
        if (state == null)
        {
            return;
        }

        GameStateController.Instance.ChangeCurrentState(state);

        var type = typeof(StateObjectsController);

        FieldInfo field = type.GetField(state, BindingFlags.NonPublic | BindingFlags.Instance);

        if (field == null) return;

        List<GameObject> list = field.GetValue(this) as List<GameObject>;

        DisableAllLists();
        SetActiveList(list, true);

    }

    public void SetActiveList(List<GameObject> objList, bool active)
    {
        foreach(var  obj in objList)
        {
            obj.SetActive(active);
        }
    }
    private void DisableAllLists()
    {
        SetActiveList(StartGame, false);
        SetActiveList(TutorialBattle, false);
    }
}
