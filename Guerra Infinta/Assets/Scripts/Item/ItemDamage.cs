using System.Globalization;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemEffects/ItemDamage")]
public class ItemDamage: ApplyItem
{
    [SerializeField] private int damageAmount;
    [SerializeField] private int ActionPointCost;
    [SerializeField] private string SfxName;
    [SerializeField] private HitEffectType EffectName;
    public override void ApplyEffect(Unit player, Unit target)
    {
        string aniItem = "AttackItem";
        int LossNumber = -1;

        Lose(LossNumber);
        player.CurrentActionPoint -= ActionPointCost;
        player.GetAnimator().SetTrigger(aniItem);
        target.StartCoroutine(target.TakeDamage(damageAmount + player.TotalDamage(), SfxName, EffectName));
    }
}