using UnityEngine;

public class Unit : MonoBehaviour, IDamageable
{
    [SerializeField] private string unitName;
    [SerializeField] private int damageBase;
    [SerializeField] private int maxHP;
    [SerializeField] private int spd;
    [SerializeField] private bool dead;
    [SerializeField] private float origenX;
    [SerializeField] private float origenY;
    [SerializeField] private int maxActionPoint;
    [SerializeField] private int currentActionPoint;

    private IAttack attackNormal;
    private int currentHP;
    private int damageBonus = 0;
    public bool attacking;
    public bool selected;
    public bool takingDamage;

    public float OrigenX
    {
        get { return origenX; }
        set { origenX = value; }
    }

    public float OrigenY
    {
        get { return origenY; }
        set { origenY = value; }
    }

    public string UnitName
    {
        get { return unitName; }
        set { unitName = value; }
    }
    public int MaxHP
    {
        get { return maxHP; }
        set { maxHP = value; }
    }

    public int CurrentHP
    {
        get { return currentHP; }
        set { currentHP = value; }
    }
    public int MaxActionPoint
    {
        get { return maxActionPoint; }
        set { maxActionPoint = value; }
    }

    public int CurrentActionPoint
    {
        get { return currentActionPoint; }
        set { currentActionPoint = value; }
    }

    public int Damage
    {
        get { return damageBase; }
    }

    public int DamageBonus
    {
        get { return damageBonus; }
        set { damageBonus = value; }
    }

    public int Spd
    {
        get { return spd; }
        set { spd = value; }
    }
    public int TotalDamage()
    {
        return damageBase + damageBonus;
    }

    public void SetPosition(float x, float y)
    {
        transform.position = new Vector2(x, y);
    }

   public void Attack(Unit target)
    {
        attackNormal.Attack(this, target);
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            currentHP = 0;
            dead = true;
        }
        Debug.Log($"{this} recebeu {damage} de dano");
    }

    public void HealAP()
    {
        CurrentActionPoint += 10;
    }

    public bool CheckDead()
    {
        dead = (currentHP <= 0);
        return dead;
        //return (currentHP <= 0) ? dead = true : dead = false;
    }


    void Awake()
    {
        attackNormal = new AttackNormal();
        currentHP = maxHP;
    }

    //-----------------------------
    public void Heal(int amout)
    {
        CurrentHP += amout;

        if (CurrentHP > MaxHP)
        {
            CurrentHP = MaxHP;
        }
    }

}