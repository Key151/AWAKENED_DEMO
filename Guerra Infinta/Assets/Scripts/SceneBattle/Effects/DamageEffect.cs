using System.Collections.Generic;
using UnityEngine;

public class DamageEffectManager : MonoBehaviour
{
    [SerializeField] private Transform effectAnchor; // ponto onde o efeito aparece
    [SerializeField] private List<HitEffectData> effects; // lista de efeitos disponiveis

    public void PlayHitEffect(HitEffectType type)
    {
        // Busca o efeito correto na lista
        HitEffectData effectData = effects.Find(e => e.type == type);
        if (effectData == null || effectData.prefab == null)
        {
            Debug.LogWarning($"Nenhum efeito configurado para {type}");
            return;
        }

        // Instancia o efeito no ponto indicado
        GameObject effect = Instantiate(effectData.prefab, effectAnchor.position, Quaternion.identity);
        Destroy(effect, 1.0f); // tempo para sumir o efeito
    }
}
