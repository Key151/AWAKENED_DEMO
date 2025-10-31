using System.Globalization;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemEffects/ItemDamage")]
public class ItemDamage: ApplyItem
{
    [SerializeField] private int damageAmount;
    [SerializeField] private int ActionPointCost;
    [SerializeField] private string SfxName;
    public override void ApplyEffect(Unit player, Unit target)
    {
        player.CurrentActionPoint -= ActionPointCost;
        target.StartCoroutine(target.TakeDamage(damageAmount + player.TotalDamage(), SfxName));
    }
}