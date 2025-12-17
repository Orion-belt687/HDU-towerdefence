using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour
{
    private GameObject turretOn;
    private Turretdata turretData;
    public bool BuildInfo;
    public GameObject BuildEffect;

    private Color OriginalColor;

    private bool isUpgraded = false;
    private void Start()
    {
        OriginalColor = GetComponent<MeshRenderer>().material.color;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject() == true) { return; }
        if (turretOn != null)
        {
            BuildManager.Instance.ShowUpgradeUI(this,transform.position, isUpgraded);
        }
        else
        {
            Turretdata selectedTD = BuildManager.Instance.selectedTurretData;
            if (selectedTD == null || selectedTD.turretPrefab == null) { return; }
            BuildTurret(selectedTD);
        }
        //if (turretOn != null) { return; }
    }

    private void BuildTurret(Turretdata _turretData)
    {
        if (BuildManager.Instance.IsEnough(_turretData.cost) == false)
        {
            return;
        }else if (BuildInfo == false)
        {
            return;
        }

            BuildManager.Instance.ChangeMoney(-_turretData.cost);
        turretData = _turretData;
        turretOn = GameObject.Instantiate(_turretData.turretPrefab, transform.position, Quaternion.identity);
        GameObject go =GameObject.Instantiate(BuildEffect, transform.position, Quaternion.identity);
        Destroy(go, 2);
    }
    private void OnMouseEnter()
    {
        if (turretOn == null&& EventSystem.current.IsPointerOverGameObject() == false&&BuildInfo==true)
        {
            GetComponent<MeshRenderer>().material.color = new Color(1f, 0.64f, 0f);
        }
    }
    private void OnMouseExit()
    {
        GetComponent<MeshRenderer>().material.color = OriginalColor;
    }
    public void OnUpgrade()
    {
        if (BuildManager.Instance.IsEnough(turretData.costUpgraded))
        {
            BuildManager.Instance.ChangeMoney(-turretData.costUpgraded);//减去升级费用
            Destroy(turretOn);
            turretOn = GameObject.Instantiate(turretData.turretUpgradedPrefab, transform.position, Quaternion.identity);
            GameObject go = GameObject.Instantiate(BuildEffect, transform.position, Quaternion.identity);
            Destroy(go, 2);
        }
    }
    public void OnTurretDestroy()
    {
        BuildManager.Instance.ChangeMoney(turretData.cost-200);//返还建造费用-200
        Destroy(turretOn);
        turretData = null;
        turretOn = null;
        GameObject go = GameObject.Instantiate(BuildEffect, transform.position, Quaternion.identity);
        Destroy(go, 2);
    }
}
