using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private string unitName;
    [SerializeField] private int unitLevel;
    [SerializeField] private int damage;
    [SerializeField] private int maxHP;
    [SerializeField] private int currentHP;
    [SerializeField] private int healHP;
    [SerializeField] private int spd;
    [SerializeField] private bool dead;
    [SerializeField] private float attackX;
    [SerializeField] private float attackY;
    [SerializeField] private float origenX;
    [SerializeField] private float origenY;
    [SerializeField] private int maxMP;
    [SerializeField] private int currentMP;
    [SerializeField] private int useMP;
    public float xPosition;
    public float yPosition;
    public bool attacking;
    public bool selected;
    public bool takingDamage;

    public float AttackX
    {
        get { return attackX; }
        set { attackX = value; }
    }

    public float AttackY
    {
        get { return attackY; }
        set { attackY = value; }
    }

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

    public int UnitLevel
    {
        get { return unitLevel; }
        set { unitLevel = value; }
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

    public int HealHP
    {
        get { return healHP; }
        set { healHP = value; }
    }
    public int MaxMP
    {
        get { return maxMP; }
        set { maxMP = value; }
    }

    public int CurrentMP
    {
        get { return currentMP; }
        set { currentMP = value; }
    }

    public int UseMP
    {
        get { return useMP; }
        set { useMP = value; }
    }

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public int Spd
    {
        get { return spd; }
        set { spd = value; }
    }
    public bool Dead
    {
        get { return dead; }
        set { dead = value; }
    }


    public void Attack(Unit target)
    {
        bool isDead = target.TakeDamage(Damage);

        if (isDead)
        {
            target.CurrentHP = 0;
            target.Dead = true;
        }

    }

    public bool TakeDamage(int dmg)
    {
        CurrentHP -= dmg;

        return CurrentHP <= 0;
    }

    public void Heal(int amout)
    {
        CurrentHP += amout;

        if (CurrentHP > MaxHP)
        {
            CurrentHP = MaxHP;
        }
    }

    public void MP()
    {
        CurrentMP = CurrentMP - UseMP;
    }

}