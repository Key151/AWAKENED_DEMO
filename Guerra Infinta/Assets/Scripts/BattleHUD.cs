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
    public Text mpText;
    public Slider mpSlider;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.UnitName;
        if (hpText != null)
        {
            hpText.text = unit.CurrentHP + "/" + unit.MaxHP;
        }
        if (mpText != null && mpSlider != null)
        {
            mpText.text = unit.CurrentMP + "/" + unit.MaxMP;
            mpSlider.maxValue = unit.MaxMP;
            mpSlider.value = unit.CurrentMP;
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

    public void SetMP(Unit unit)
    {
        mpSlider.value = unit.CurrentMP;
        mpText.text = unit.CurrentMP + "/" + unit.MaxMP;

    }
}