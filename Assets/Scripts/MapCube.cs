using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject() == true) { return; }
        Turretdata selectedTD = BuildManager.Instance.selectedTurretData;
        if (selectedTD == null||selectedTD.turretPrefab==null) { return; }

        GameObject.Instantiate(selectedTD.turretPrefab, transform.position, Quaternion.identity);
    }
}
