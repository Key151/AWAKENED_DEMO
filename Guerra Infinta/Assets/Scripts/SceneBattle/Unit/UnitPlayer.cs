using System.Collections.Generic;
using UnityEngine;
using static BattleSystem;

public class UnitPlayer : Unit, IVerificateTurnUnit
{
    private float attackX = -2f;
    private float attackY = 0f;
    [SerializeField] private List<ItemWeaponEquip> ItemEquipment;
    private PlayerData playerData;

    private readonly Dictionary<TypeItem, ItemWeaponEquip> equippedItems = new(); //CASO TIVER MAIS DE UM ITEM EQUIPAVEL
    public BattleState turnUnit()
    {
        return BattleState.PLAYERTURN;
    }

    public void MoveAtk(Transform enemy)
    {
        float playerPositionX = enemy.position.x + attackX;
        float playerPositionY = enemy.position.y + attackY;
        transform.position = new Vector2(playerPositionX, playerPositionY);
    }

    public void EquipItem(ItemWeaponEquip newItem)
    {
        if (equippedItems.TryGetValue(newItem.TipoWeapon, out ItemWeaponEquip currentWeapon))
        {
            currentWeapon.Unequip(this);
            Debug.Log("Desequipado com sucesso!");
        }

        equippedItems[newItem.TipoWeapon] = newItem; // Adiciona o novo item equipavel ao dicionário
        newItem.Equip(this);
        Debug.Log("Equipado com sucesso!");
    }

    void Start()
    {
        if (ItemEquipment != null)
        {
            foreach (var item in ItemEquipment) // Usa for para verificar todos os itens equipados
            {
                EquipItem(item);
                Debug.Log($"Está com {item.ItemName}!");
            }
        }

    }

    protected override void Awake()
    {
        base.Awake();
        // Tenta carregar dados existentes
        var savedPlyer = PlayerManager.Instance.LoadPlayer(UnitName);

        if (savedPlyer != null)
        {
            // Se já existe, fica com ultimo HP
            CurrentHP = savedPlyer.hp;
        }
    }

    public void SaveData() {
        playerData = new PlayerData
        {
            playerId = UnitName,
            hp = CurrentHP
        };
        PlayerManager.Instance.SavePlayer(playerData);
    }
}