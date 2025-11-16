using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    public GameObject hudImage;

    [Header("HP")]
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private Slider hpSlider;

    [Header("AP")]
    [SerializeField] private TextMeshProUGUI ActionPointText;
    [SerializeField] private Slider ActionPointSlider;

    //[SerializeField] private ParticleSystem particle;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.UnitName;

        UpdateHPText(unit);

        if (ActionPointSlider != null)
        {
            ActionPointSlider.maxValue = unit.MaxActionPoint;
            ActionPointSlider.value = unit.CurrentActionPoint;
        }

        hpSlider.maxValue = unit.MaxHP;
        hpSlider.value = unit.CurrentHP;
        //DisactiveHudImage();
    }

    public void EnemySetHP(int hp)
    {
        hpSlider.value = hp;
    }

    public IEnumerator PlayerSetHP(int hp)
    {
        //particle.Play();
        while(hpSlider.value > hp)
        {
            hpSlider.value--;
            yield return new WaitForSeconds(0.02f);
        }
    }

    public IEnumerator PlayerSetAP(int ap)
    {
        //particle.Play();
        while (ActionPointSlider.value > ap)
        {
            ActionPointSlider.value--;
            yield return new WaitForSeconds(0.02f);
        }
    }

    public void UpdateHPText(Unit unit)
    {
        if (hpText != null)
        {
            hpText.text = unit.CurrentHP + "/" + unit.MaxHP;
        }
    }

    public void UpdateAPText(Unit unit)
    {
        if (hpText != null)
        {
            ActionPointText.text = unit.CurrentActionPoint + "/" + unit.MaxActionPoint;
        }
    }


    public void ActiveHudImage()
    {
        if (hudImage != null)
        {
            hudImage.SetActive(true);
        }
        else
        {
            return;
        }
    }

    public void DisactiveHudImage()
    {
        if(hudImage != null)
        {
            hudImage.SetActive(false);
        }
        else
        {
            return;
        }
    }

    public void UpdateHUD(Unit unit)
    {
        StartCoroutine(PlayerSetHP(unit.CurrentHP));
        UpdateHPText(unit);
    }

    public void UpdateApHUD(Unit unit)
    {
        StartCoroutine(PlayerSetAP(unit.CurrentActionPoint));
        UpdateAPText(unit);
    }

}