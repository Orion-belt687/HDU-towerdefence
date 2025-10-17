using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 20;
    /* Start is called before the first frame update
    void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");//zAxis
        float moveY = 0f;
        if (Input.GetKey(KeyCode.Space)) // �ո������
        {
            moveY = 1f;
        }
        else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) // Shift������
        {
            moveY = -1f;
        }
        float moveZ = Input.GetAxisRaw("Vertical");//xAxis

        transform.Translate(new Vector3(moveX,moveY*0.8f, moveZ)*Time.deltaTime*speed,Space.World);
    }
}
