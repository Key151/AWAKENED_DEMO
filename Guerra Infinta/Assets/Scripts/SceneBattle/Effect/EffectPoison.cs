using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Poison")]
public class EffectPoison : ScriptableObject, IEffects
{
    [SerializeField] private int damagePerTurn;
    [SerializeField] private int duration;
    public void Effect(Unit target)
    {
        target.StartCoroutine(target.TakeDamage(damagePerTurn));
    }

    public bool verificate()
    {
        if (duration > 0)
        {
            return true;
        }
        duration -= 1;
        return false;
    }
}