using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Unit : MonoBehaviour, IDamageable
{
    [SerializeField] private string unitName;
    [SerializeField] private int damage;
    [SerializeField] private int maxHP;
    [SerializeField] private int currentHP;
    [SerializeField] private int spd;
    [SerializeField] private bool dead;
    [SerializeField] private float attackX;
    [SerializeField] private float attackY;
    [SerializeField] private float origenX;
    [SerializeField] private float origenY;
    [SerializeField] private int maxActionPoint;
    [SerializeField] private int currentActionPoint;

    public AttackNormal attackNormal;
    public bool attacking;
    public bool selected;
    public bool takingDamage;

    public float AttackX
    {
        get { return attackX; }
        set { attackX = value - 2f; }
    }

    public float AttackY
    {
        get { return attackY; }
        set { attackY = value + 1.2f; }
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
        get { return damage; }
        set { damage = value; }
    }

    public int Spd
    {
        get { return spd; }
        set { spd = value; }
    }
    public void SetPosition(float x, float y)
    {
        this.transform.position = new Vector2(x, y);
    }

   public void Attack(Unit target)
    {
        attackNormal.Attack(this, target);
    }

    public void TakeDamage(int damage)
    {
        this.currentHP -= damage;
        if (this.currentHP <= 0)
        {
            this.currentHP = 0;
            this.dead = true;
        }
    }

    public bool CheckDead()
    {
        if (this.currentHP <= 0)
        {
            this.dead = true;
        }
        else
        {
            this.dead = false;
        }
        return this.dead;
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