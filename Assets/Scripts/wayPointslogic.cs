using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wayPointslogic : MonoBehaviour
{
    public static wayPointslogic Instance { get; private set;  }

    private List<Transform> waypointList;

    private void Awake()
    {
        Instance = this;
        Init();
    }

    private void Init()
    {
        Transform[] transforms=transform.GetComponentsInChildren<Transform>();
        waypointList = new List<Transform>(transforms);
        waypointList.RemoveAt(0);
    }
   public int GetLength()
    {
        return waypointList.Count;
    }
    public Vector3 GetwayPoint(int index)
    {
        return waypointList[index].position;
    }
}
