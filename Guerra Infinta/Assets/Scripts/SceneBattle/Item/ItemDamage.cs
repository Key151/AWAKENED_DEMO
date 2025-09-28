using UnityEngine;

[CreateAssetMenu(menuName = "ItemEffects/ItemDamage")]
public class ItemDamage: ApplyItem
{
    [SerializeField] private int damageAmount;

    public override void ApplyEffect(Unit player, Unit target)
    {
        target.StartCoroutine(target.TakeDamage(damageAmount + player.TotalDamage()));
    }
}