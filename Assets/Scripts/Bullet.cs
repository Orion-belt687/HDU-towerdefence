using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 50;
    public float speed = 30;
    public Transform target;
    //public Transform transform1;
    public GameObject explotionEffect;
    //public List<GameObject> enemyList = new List<GameObject>();


    public void Update()
    {
        if (target == null) // 怪没了就销毁
        {
            Disappear();
            return;
        }
        //让子弹飞
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //transform1 = target.Find("BotsBody");
        if (Vector3.Distance(transform.position, target.position) < 1)
        {
            Disappear();
            target.GetComponentInParent<enemyLogic>().TakeDamage(damage);
        }
        
    }

    public void SetTarget(Transform _target)
    {
        this.target = _target;
    }
    private void Disappear()
    {
        Destroy(this.gameObject);
        GameObject go = GameObject.Instantiate(explotionEffect, transform.position, Quaternion.identity);
        Destroy(go, 2);
        if (target != null)
        {
            go.transform.parent = target.transform;
        }
    }

}
