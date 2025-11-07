using UnityEngine;

[CreateAssetMenu(menuName = "Items/WeaponEquip")]
public class ItemWeaponEquip  : Item, IEquipment
{
    public TypeItem TipoWeapon => TypeItem.EquipWeapon;

    [SerializeField] private int bonusDamage; // Exemplo de bônus de dano

    [SerializeField] private string SfxName;
    public void Equip(UnitPlayer player)
    {
        player.DamageBonus += bonusDamage;
        Debug.Log($"{ItemName()} equipada! Dano aumentado em {bonusDamage}.");
    }
    public void Unequip(UnitPlayer player)
    {
        player.DamageBonus -= bonusDamage;
        Debug.Log($"{ItemName()} desequipada! Dano reduzido em {bonusDamage}.");
    }
}