using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance { get; private set; }
    public Turretdata StandardTurretData;
    public Turretdata MissleTurretData;
    public Turretdata LaserTurretData;

    public Turretdata selectedTurretData;
    private void Awake()
    {
        Instance = this;
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
}
