using UnityEngine;

[CreateAssetMenu(menuName = "Items/WeaponEquip")]
public class ItemWeaponEquip  : Item, IEquipment
{
    public TipoItem TipoWeapon => TipoItem.EquipWeapon;
    public string ItemName => itemName;
    public string Description => description;

    [SerializeField] private int bonusDamage; // Exemplo de bônus de dano
    public void Equip(UnitPlayer player)
    {
        player.DamageBonus += bonusDamage;
        Debug.Log($"{ItemName} equipada! Dano aumentado em {bonusDamage}.");
    }
    public void Unequip(UnitPlayer player)
    {
        player.DamageBonus -= bonusDamage;
        Debug.Log($"{ItemName} desequipada! Dano reduzido em {bonusDamage}.");
    }
}