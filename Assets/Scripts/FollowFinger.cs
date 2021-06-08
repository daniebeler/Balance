using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFinger : MonoBehaviour
{
    private Rigidbody2D rigid;

    private Vector3 playerpos;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerpos = new Vector3(0, -0.8f, 0);
    }

    void FixedUpdate()
    {

        if (Input.touchCount > 0)
        {
            playerpos = new Vector3(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x, Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y, 0);
        }
        else if (Input.GetMouseButton(0))
        {
            playerpos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        }


        transform.position = playerpos;
    }
}
