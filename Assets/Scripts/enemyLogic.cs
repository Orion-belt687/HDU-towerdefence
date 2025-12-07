using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class enemyLogic : MonoBehaviour
{
    private int wayIndex = 0;
    private Vector3 targetPosition = Vector3.zero;
    public float speed = 4;
    public int hp = 100;
    public int maxHp = 100;
    public bool isDead = false;
    private UnityEngine.UI.Slider hpSlider;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = wayPointslogic.Instance.GetwayPoint(wayIndex);
        hp = maxHp;
        hpSlider = transform.Find("Canvas/HPSlider").GetComponent<UnityEngine.UI.Slider>();
        hpSlider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            transform.Translate((targetPosition - transform.position).normalized * speed * Time.deltaTime, Space.World);
        }
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
            Disappear(false);
            return;
        }
        targetPosition = wayPointslogic.Instance.GetwayPoint(wayIndex);
        transform.LookAt(targetPosition);//有问题
    }
    void Disappear(bool isShot)//倒地or消失，isshot为真时，播放倒地红温特效（被打倒了
    {
        if (isShot == true)
        {
            isDead = true;
            // 表面变红
            var renderers = GetComponentsInChildren<Renderer>();
            foreach (var r in renderers)
            {
                foreach (var mat in r.materials)
                {
                    mat.color = Color.red;
                }
            }

            // 启动缓慢倒下协程
            StartCoroutine(FallDown());
            EnemySpawner.Instance.DecreateEnemyCount();
            Destroy(gameObject, 0.5f);

        }
        else
        {
            EnemySpawner.Instance.DecreateEnemyCount();
            Destroy(gameObject);
        }

        
        //GG,还没写
    }


    IEnumerator FallDown()//让敌人倒下
    {
        Transform canvasUI = transform.Find("Canvas");
        if (canvasUI != null)
        {
            canvasUI.SetParent(null); // 解绑
            Destroy(canvasUI.gameObject);
        }

        Quaternion startRot = transform.rotation;
        Quaternion endRot = Quaternion.Euler(transform.eulerAngles + new Vector3(90, 0, 0));
        float duration = 0.3f; // 倒下所需时间（秒）
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Lerp(startRot, endRot, elapsed / duration);
            transform.Translate(new Vector3(0,2,0)*Time.deltaTime,Space.World);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = endRot; // 最终角度
    }
    public void TakeDamage(int damage)//造成伤害
    {
        hp -= damage;
        hpSlider.value = (float)hp / maxHp;
        if (hp <= 0)
        {
            Disappear(true);
        }
    }
}
