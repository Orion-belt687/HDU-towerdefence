using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance { get; private set; }
    public Turretdata StandardTurretData;
    public Turretdata MissleTurretData;
    public Turretdata LaserTurretData;

    public Turretdata selectedTurretData;
    public TextMeshProUGUI MoneyText;
    private Animator moneyTextAnimator;
    private int money = 1000;

    public UpGradeUI upgradeUI;
    private MapCube upgradeCube;
    private void Awake()
    {
        Instance = this;
        moneyTextAnimator = MoneyText.GetComponent<Animator>();
    }
    public void OnStandardSlelcted(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData= StandardTurretData;
        }
    }
    public void OnMissleSlelcted(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = MissleTurretData;
        }
    }
    public void OnLaserSlelcted(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = LaserTurretData;
        }
    }

    public bool IsEnough(int need)
    {
        if (need <= money)
        {
            return true;
        }
        else
        {
            MoneyFlicker();
            return false;
        }
            //return need <= money;
    }
    public void ChangeMoney(int value)
    {
        this.money += value;
        MoneyText.text = "Total Money:\n"+money.ToString();
    }
    private void MoneyFlicker()
    {
        moneyTextAnimator.SetTrigger("MoneyLack");
    }
    public void ShowUpgradeUI(MapCube cube,Vector3 position,bool isDisableUpgrade)
    {
        upgradeCube = cube;
        upgradeUI.Show(position, isDisableUpgrade);
    }
    public void HideUpgradeUI()
    {
        upgradeUI.Hide();
    }
    public void OnUpgrade()
    {
        upgradeCube?.OnUpgrade();
        HideUpgradeUI();
    }
    public void OnTurretDestroy()
    {
        upgradeCube?.OnTurretDestroy();
        HideUpgradeUI();
    }
}
