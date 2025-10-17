using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Text levelText;
    public Text hpText;
    public Slider hpSlider;
    public TextMeshPro nameTextMesh;
    public Text ActionPointText;
    public Slider ActionPointSlider;
    public GameObject hudImage;

    //[SerializeField] private ParticleSystem particle;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.UnitName;

        UpdateHPText(unit);
        /*if (ActionPointText != null && ActionPointSlider != null)
        {
            ActionPointText.text = unit.CurrentActionPoint + "/" + unit.MaxActionPoint;
            ActionPointSlider.maxValue = unit.MaxActionPoint;
            ActionPointSlider.value = unit.CurrentActionPoint;
        }*/
        hpSlider.maxValue = unit.MaxHP;
        hpSlider.value = unit.CurrentHP;
        Debug.Log(unit.name + " tem " + unit.CurrentHP + " de vida");
        DisactiveHudImage();
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

    public void UpdateHPText(Unit unit)
    {
        if (hpText != null)
        {
            hpText.text = unit.CurrentHP + "/" + unit.MaxHP;
        }
    }

    public void SetActionPoint(Unit unit)
    {
        ActionPointSlider.value = unit.CurrentActionPoint;
        ActionPointText.text = unit.CurrentActionPoint + "/" + unit.MaxActionPoint;

    }

    public void ActiveHudImage()
    {
        hudImage.SetActive(true);
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


}