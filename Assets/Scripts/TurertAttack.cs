using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurertAttack : MonoBehaviour
{
    public List<GameObject> enemyList=new List<GameObject>();
    public float attackRate = 1;
    public GameObject bulletPrefab;
    public Transform BulletPosition;
    public float nextAttackTime;//Time.time,到了时间就射击

    private Transform Head;

    private void Start()
    {
        Head = transform.Find("Head");

    }
    private void Update()
    {
        Attack();
        DirectionControl();
    }
    private void OnTriggerEnter(Collider other)//敌人进来判定
    {
        if (other.tag == "enemy")
        {
            enemyList.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)//敌人出去判定
    {
        if (other.tag == "enemy")
        {
            enemyList.Remove(other.gameObject);
        }

    }
    private void Attack()
    {
        if (enemyList == null || enemyList.Count == 0) return;
        //GameObject go=enemyList[0];
        if (Time.time > nextAttackTime)
        {
            Transform target = GetTarget();
            if (target != null)
            {
                GameObject go = GameObject.Instantiate(bulletPrefab, BulletPosition.position, Quaternion.identity);
                go.GetComponent<Bullet>().SetTarget(enemyList[0].transform);
                nextAttackTime = Time.time + attackRate;
            }
        }
    }
    public Transform GetTarget()
    {
        List<int> indexList = new List<int>();
        for(int i = 0; i < enemyList.Count; i++)//这俩循环用于移除enemylist里的已经进点/被消灭的空敌人
        {
            if (enemyList[i] == null || enemyList[i].Equals(null))
            {
                indexList.Add(i);
            }
        }
        for(int i = indexList.Count - 1; i >= 0; i--)
        {
            enemyList.RemoveAt(indexList[i]);
        }
        if (enemyList != null && enemyList.Count != 0)
        {
            return enemyList[0].transform;
        }
        return null;
    }
    private void DirectionControl()
    {
        GameObject target=null;
        if (enemyList != null && enemyList.Count > 0)
        {
            target = enemyList[0];
        }
        if (target == null)
        {
            return;
        }
        Vector3 targetPos = target.transform.position;
        targetPos.y = (targetPos.y + Head.position.y) / 3;
        Head.LookAt(targetPos);
    }
}
