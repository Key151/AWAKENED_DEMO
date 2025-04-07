using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Text levelText;
    public Text hpText;
    public Slider hpSlider;
    public Text PPText;
    public Slider PPSlider;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.UnitName;
        if (hpText != null)
        {
            hpText.text = unit.CurrentHP + "/" + unit.MaxHP;
        }
        if (PPText != null && PPSlider != null)
        {
            PPText.text = unit.CurrentPP + "/" + unit.MaxPP;
            PPSlider.maxValue = unit.MaxPP;
            PPSlider.value = unit.CurrentPP;
        }
        if (levelText != null)
        {
            levelText.text = "Lvl " + unit.UnitLevel;
        }
        hpSlider.maxValue = unit.MaxHP;
        hpSlider.value = unit.CurrentHP;
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }

    public void UpdateHPText(Unit unit)
    {
        hpText.text = unit.CurrentHP + "/" + unit.MaxHP;
    }

    public void SetPP(Unit unit)
    {
        PPSlider.value = unit.CurrentPP;
        PPText.text = unit.CurrentPP + "/" + unit.MaxPP;

    }
}