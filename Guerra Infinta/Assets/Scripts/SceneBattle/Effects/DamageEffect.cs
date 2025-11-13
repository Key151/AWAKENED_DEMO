using System.Collections.Generic;
using UnityEngine;

public class DamageEffectManager : MonoBehaviour
{
    //SerializeField] 
    private Animator effectAnimator;

    private Dictionary<HitEffectType, string> effectAnimations;

    private void Awake()
    {
        effectAnimator = GetComponent<Animator>();
        // associa cada tipo ao nome da animacao
        effectAnimations = new Dictionary<HitEffectType, string>
            {
                { HitEffectType.Normal , "Effect1" },
                { HitEffectType.Explosion, "CriticalEffect" },
                { HitEffectType.Pistol, "FireEffect" },
                { HitEffectType.Slash, "PoisonEffect" },
                { HitEffectType.Shotgun, "HealEffect" }
            };
    }

    public void PlayHitEffect(HitEffectType type)
    {
        if (effectAnimations.TryGetValue(type, out string triggerName))
        {
            //effectAnimator.ResetTrigger(triggerName);
            effectAnimator.SetTrigger(effectAnimations[type]);
        }
        else
        {
            Debug.LogWarning($"Efeito '{type}' nao encontrado no dicionario!");
        }
    }
}