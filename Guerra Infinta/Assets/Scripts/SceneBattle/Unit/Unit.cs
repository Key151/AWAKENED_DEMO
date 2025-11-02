using System.Collections;
using UnityEngine;

public class Unit : MonoBehaviour, IDamageable
{
    [SerializeField] private string unitName;
    [SerializeField] private int damageBase;
    [SerializeField] private int maxHP;
    [SerializeField] private int spd;

    [SerializeField] private int maxActionPoint;
    

    private IAttack attackNormal;
    private int currentHP;
    private int currentActionPoint;
    private int damageBonus = 0;
    private bool dead;
    public bool Attacking { get; set; }
    public bool Selected { get; set; }
    public bool TakingDamage { get; set; }

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

   public virtual void Attack(Unit target)
    {
        attackNormal.Attack(this, target);
    }

    public virtual IEnumerator TakeDamage(int damage, string sfx = "BattleEffect12")
    {
        AudioManager.Instance.PlaySFX(sfx, true);
        currentHP -= damage;
        if (currentHP <= 0)
        {
            currentHP = 0;
            dead = true;
        }
        Debug.Log($"{this} recebeu {damage} de dano");
        yield return new WaitForSeconds(1f);
    }

    public void HealAP()
    {
        int maxAP = 100;
        CurrentActionPoint += 6;
        CurrentActionPoint = Mathf.Clamp(CurrentActionPoint, 0, maxAP);
    }

    public virtual bool CheckDead()
    {
        dead = (currentHP <= 0);
        return dead;
        //return (currentHP <= 0) ? dead = true : dead = false;
    }


    protected virtual void Awake()
    {
        attackNormal = new AttackNormal();
        currentHP = maxHP;
        currentActionPoint = maxActionPoint;
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