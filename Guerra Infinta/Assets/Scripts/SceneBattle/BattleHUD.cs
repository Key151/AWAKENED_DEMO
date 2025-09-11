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

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.UnitName;
        if (hpText != null)
        {
            hpText.text = unit.CurrentHP + "/" + unit.MaxHP;
        }
        if (ActionPointText != null && ActionPointSlider != null)
        {
            ActionPointText.text = unit.CurrentActionPoint + "/" + unit.MaxActionPoint;
            ActionPointSlider.maxValue = unit.MaxActionPoint;
            ActionPointSlider.value = unit.CurrentActionPoint;
        }
        //if (levelText != null)
        //{
        //    levelText.text = "Lvl " + unit.UnitLevel;
        //}
        hpSlider.maxValue = unit.MaxHP;
        hpSlider.value = unit.CurrentHP;
        DisactiveHudImage();
    }

    public void SetHP(int hp)
    {
        while(hpSlider.value != hp)
        {
            hpSlider.value--;
        }
    }

    public void UpdateHPText(Unit unit)
    {
        hpText.text = unit.CurrentHP + "/" + unit.MaxHP;
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

}