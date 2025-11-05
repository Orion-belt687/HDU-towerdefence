using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Turretdata
{
    public GameObject turretPrefab;
    public int cost;
    public GameObject turretUpgradedPrefab;
    public int costUpgraded;
    public Turrettype type;
}
public enum Turrettype
{
    StandardTurret,
    MissleTurret,
    LaserTurret
}