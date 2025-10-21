using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLogic : MonoBehaviour
{
    private int wayIndex = 0;
    private Vector3 targetPosition = Vector3.zero;
    public float speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = wayPointslogic.Instance.GetwayPoint(wayIndex);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((targetPosition - transform.position).normalized * speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPosition) < 0.2f)
        {
            moveToNext();
        }
    }
    private void moveToNext()
    {
        wayIndex++;
        if (wayIndex >= (wayPointslogic.Instance.GetLength()))//到最后点，进门了
        {
            Disappear();
            return;
        }
        targetPosition = wayPointslogic.Instance.GetwayPoint(wayIndex);
    }
    void Disappear()
    {
        Destroy(gameObject);
        EnemySpawner.Instance.DecreateEnemyCount();
        //GG,还没写
    }
}
