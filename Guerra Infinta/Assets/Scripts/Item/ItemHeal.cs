using System.Globalization;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemEffects/ItemHeal")]
public class ItemHeal : ApplyItem
{
    [SerializeField] private int Heal;
    [SerializeField] private int ActionPointCost;
    [SerializeField] private string SfxName;
    [SerializeField] private HitEffectType EffectName;
    public override void ApplyEffect(Unit player, Unit target)
    {
        string SE = "Drink";
        player.CurrentActionPoint -= ActionPointCost;
        AudioManager.Instance.PlaySFX(SE);
        target.CurrentHP += Heal;
    }
}