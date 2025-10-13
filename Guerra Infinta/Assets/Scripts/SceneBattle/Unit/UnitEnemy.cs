
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using static BattleSystem;

public class UnitEnemy : Unit, IVerificateTurnUnit
{
    [SerializeField] private DamageText textDamage;
    private CinemachineImpulseSource impulseSource;
    private SpriteRenderer spriteRenderer;
    private CameraShake cameraShake;
    private Color flashColor = Color.red;
    private float flashDuration = 0.5f;
    private Color originalColor;

    public void Start()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        cameraShake = GameObject.Find("CameraShake").GetComponent<CameraShake>();
        originalColor = spriteRenderer.color;
    }

    public override bool CheckDead()
    {
        return base.CheckDead();
    }

    public override IEnumerator TakeDamage(int damage)
    {
        textDamage.ShowDamage(damage);
        StartCoroutine(Flash());
        StartCoroutine(base.TakeDamage(damage));
        yield return new WaitForSeconds(1f);
    }

    public override void Attack(Unit target)
    {
        base.Attack(target);
        impulseSource.GenerateImpulse();
        //cameraShake.StartShake();
    }

    public BattleState turnUnit()
    {
        return BattleState.ENEMYTURN;
    }

    private IEnumerator Flash()
    {
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }

}