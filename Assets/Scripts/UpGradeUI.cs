using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UpGradeUI : MonoBehaviour
{
    private Animator anim;

    public UnityEngine.UI.Button UpGrade;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    /*这个函数用来测试
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Show(Vector3.zero, false);
        }else if (Input.GetMouseButtonDown(1))
        {
            Hide();
        }
    }*/
    public void Show(Vector3 position,bool isDisableUpgrade)
    {
        if (transform.localScale != Vector3.zero && transform.position==position)
        {
            Hide();
            return;
        }
        UpGrade.interactable = !isDisableUpgrade;
        transform.position = position;
        anim.SetBool("IsShow", true);
    }
    public void Hide()
    {
        anim.SetBool("IsShow", false);
    }

    public void OnUpgradeButtonClick()
    {
        BuildManager.Instance.OnUpgrade();
    }
    public void OnDestrotButtonClick()
    {
        BuildManager.Instance.OnTurretDestroy();
    }
}
