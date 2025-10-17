using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using static BattleSystem;

public class UnitEnemy : Unit, IVerificateTurnUnit
{
    [Header("ShowIcon")]
    [SerializeField] private DamageText textDamage;
    [SerializeField] private TimeIcon iconAction;

    private CinemachineImpulseSource impulseSource;
    private SpriteRenderer spriteRenderer;
    private CameraShake cameraShake;
    private Color flashColor = Color.red;
    private float flashDuration = 0.5f;
    private Color originalColor;

    [Header("Animation")]
    private Animator anim;
    private string hurt = "Hurt";
    private string dead = "Dead";
    private string attack = "Attack";

    public void Start()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        cameraShake = GameObject.Find("CameraShake").GetComponent<CameraShake>();
        originalColor = spriteRenderer.color;
    }

    public override bool CheckDead()
    {
        return base.CheckDead();
    }

    public void ShowIcon()
    {
        iconAction.StartActionIcon();
    }

    public override IEnumerator TakeDamage(int damage)
    {
        textDamage.ShowDamage(damage);
        StartCoroutine(Flash());
        StartCoroutine(base.TakeDamage(damage));
        if (CheckDead())
        {
            anim.SetTrigger(dead);
        }
        else
        {
            anim.SetTrigger(hurt);
        }
        yield return new WaitForSeconds(1f);
    }

    public override void Attack(Unit target)
    {
        anim.SetTrigger(attack);
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