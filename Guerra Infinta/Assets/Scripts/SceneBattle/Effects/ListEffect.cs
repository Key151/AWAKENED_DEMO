using UnityEngine;

[CreateAssetMenu(menuName = "EffectsHits")]
public class HitEffectData : ScriptableObject
{
    public HitEffectType type;
    public GameObject prefab;
}