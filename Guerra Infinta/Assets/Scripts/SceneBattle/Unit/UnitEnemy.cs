using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Animations;
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
    private string hurtAni = "Hurt";
    private string deadAni = "Dead";
    private string attackAni = "Attack";

    [Header("SoundEffect")]
    private string effect09 = "BattleEffect09";
    private string effect12 = "BattleEffect12";
    private string effect18 = "BattleEffect18";

    private bool isClicked;

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

    public override IEnumerator TakeDamage(int damage, string sfx= "BattleEffect18")
    {
        textDamage.ShowDamage(damage);
        StartCoroutine(Flash());
        AudioManager.Instance.PlaySFX(sfx, true);
        StartCoroutine(base.TakeDamage(damage));
        if (CheckDead())
        {
            anim.SetTrigger(deadAni);
        }
        else
        {
            anim.SetTrigger(hurtAni);
        }
        yield return new WaitForSeconds(1f);
    }

    public override void Attack(Unit target)
    {
        anim.SetTrigger(attackAni);
        //AudioManager.Instance.PlaySFX(effect12, true);
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

    public bool ClickEnemy()
    {
        isClicked = false;
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if(hit.collider != null && hit.collider.transform == this.transform)
            {
                Debug.Log("Clicou no inimigo " + UnitName);
                isClicked = true;
            }
            else
            {
                Debug.Log("Nao clicou no inimigo " + UnitName);
            }
        }
        return isClicked;
    }

}