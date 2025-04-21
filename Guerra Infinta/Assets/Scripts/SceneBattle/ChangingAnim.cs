using UnityEngine;

public class ChangingAnim : MonoBehaviour
{

    private Animator mAnimator;
    string currentState;
    //public bool animAttack;
    //Unit playerUnit_2;

    [SerializeField] UnitPlayerBoy Unit;

    const string Idle = "Idle";
    const string Attack = "Attack";
    const string Idle_Selected = "Idle_Selected";
    const string Takng_Damage = "Taking_Damage";
    const string Dead = "Dead";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame

    void ChangeAnimatonState(string newState)
    {
        if (currentState == newState) return;

        mAnimator.Play(newState);
        currentState = newState;
    }

    void Update()
    {
        if(Unit.checkDead())
        {
            ChangeAnimatonState(Dead);
        }
        else if(Unit.attacking)
        {
            ChangeAnimatonState(Attack);
        }
        else if(Unit.takingDamage)
        {
            ChangeAnimatonState(Takng_Damage);
        }
        else
        {
            if (Unit.selected)
            {
                ChangeAnimatonState(Idle_Selected);
            }
            else
            {
                ChangeAnimatonState(Idle);
            }
        }
    }
}
