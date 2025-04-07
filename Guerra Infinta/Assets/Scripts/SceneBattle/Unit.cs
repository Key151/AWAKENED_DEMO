using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.VisualScripting;
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
    [SerializeField] private int maxPP; // PP = Power Point
    [SerializeField] private int currentPP;
    [SerializeField] private int usePP;

    private IAttack attack;

    public float xPosition;
    public float yPosition;
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
    public int MaxPP
    {
        get { return maxPP; }
        set { maxPP = value; }
    }

    public int CurrentPP
    {
        get { return currentPP; }
        set { currentPP = value; }
    }

    public int UsePP
    {
        get { return usePP; }
        set { usePP = value; }
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
    private void Start()
    {
        attack = GetComponent<IAttack>();
    }

    public void Attack(Unit target)
    {
        attack?.Attack(this, target);
        attacking = true;
    }
    public void MoveAtk(Transform enemy)
    {
        //posição de ataque
        float playerPositionX = enemy.position.x + AttackX;
        float playerPositionY = enemy.position.y + AttackY;
        this.transform.position = new Vector2(playerPositionX, playerPositionY);
    }
    public bool TakeDamage(int dmg)
    {
        CurrentHP -= dmg;

        return CurrentHP <= 0;
    }
    public void PP()
    {
        CurrentPP = CurrentPP - UsePP;
    }


    public void Heal(int amout)
    {
        CurrentHP += amout;

        if (CurrentHP > MaxHP)
        {
            CurrentHP = MaxHP;
        }
    }

}